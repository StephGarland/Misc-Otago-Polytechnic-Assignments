#include "StdAfx.h"
#include "Grid.h"
using namespace System::Drawing;

///
/// The Grid class: the board on which the game takes place.
///

///
///Grid constructor: requires an array of sounds effects, sets initial data member values.
///
Grid::Grid(array<WMPLib::WindowsMediaPlayer^>^ soundFX)
{
	this->soundFX = soundFX;

	score = 0;
	state = GameState::Idle;
	random = gcnew Random();
	turnCounter = 0;

	//images that represent the game balls
	images = gcnew array<Image^>(6);
	images[0] = Image::FromFile("catNexusBall_blue.png");
	images[1] = Image::FromFile("catNexusBall_green.png");
	images[2] = Image::FromFile("catNexusBall_red.png");
	images[3] = Image::FromFile("catNexusBall_purple.png");
	images[4] = Image::FromFile("catNexusBall_yellow.png");
	images[5] = Image::FromFile("catNexusBall_aqua.png");
	
	whitePen = gcnew Pen(Brushes::White);
	whitePen->Width = 3.0F;

	undoScore = gcnew List<int>();
	redoScore = gcnew List<int>();
	undoState = gcnew List<array<GridCell^, 2>^>();
	redoState = gcnew List<array<GridCell^, 2>^>();
	currentState = gcnew array<GridCell^, 2>(n_columns, n_rows);

	for(int i=0; i < n_columns; i++)
	{
		for(int j=0; j < n_rows; j++)
		{
			currentState[i, j] = gcnew GridCell(i, j);
		}
	}	
}

///
///Draws the most current grid setup (including contents and highlighting of selected cell)
///Requires a graphics object.
///
void Grid::Draw(Graphics^ graphics)
{
	//for every cell in the grid
	for each(GridCell^ cell in currentState)
	{
		//the pixel location the cell is drawn at
		int x = cell->X * CELL_SIZE;
		int y = cell->Y * CELL_SIZE;
		//draw a  border around the cell
		graphics->DrawRectangle(Pens::DarkSlateGray, x, y, CELL_SIZE, CELL_SIZE);

		//if it's not empty, draw its contents
		if(cell->Contents != CellContents::Empty)
		{
			graphics->DrawImage(images[(int)cell->Contents], x, y, CELL_SIZE, CELL_SIZE);
		}
	}
	//if there's a selected cell, distinguish it.
	if (selectedCell != nullptr)
	{
		int x = selectedCell->X * CELL_SIZE;
		int y = selectedCell->Y * CELL_SIZE;
		graphics->DrawRectangle(whitePen, x, y, CELL_SIZE, CELL_SIZE);
	}
}

///
///Returns a count of the cells that are empty
///
int Grid::GetNEmptyCells()
{
	int nEmptyCells = 0;
	for each(GridCell^ cell in currentState)
	{
		if(cell->Contents == CellContents::Empty)
		{
			nEmptyCells++;
		}
	}
	return nEmptyCells;
}

///
///Accepts coordinates, returns true if the coordinates are within the grid bounds.
///
bool Grid::Contains(int x, int y)
{
	//are the given coordinates within the grid?
	return x < currentState->GetLength(0) && y < currentState->GetLength(1) && x >= 0 && y >= 0;
}

///
///Accepts coordinates, returns true if the cell at that position is empty.
///
bool Grid::Empty(int x, int y)
{
	return currentState[x, y]->Contents == CellContents::Empty;
}

///
///Returns a list of pathpoints between two given points.
///
List<PathPoint^>^ Grid::FindPath(Point origin, Point destination)
{
	//the counter map will collect pathpoints as detailed below, 
	//and once a path has been found, the countermap will be optimised into a 'best path' list.
	List<PathPoint^>^ counterMap = gcnew List<PathPoint^>();
	PathPoint^ endCoordinate = gcnew PathPoint(destination, 0);
	counterMap->Add(endCoordinate);
	bool mapComplete = false;

	for(int i = 0; i < counterMap->Count && mapComplete == false; i++)
	{
		//a list of all cells that are adjacent to pathpoints from the previous step.
		List<PathPoint^>^adjacentCells = gcnew List<PathPoint^>();
		adjacentCells->Add(gcnew PathPoint(counterMap[i]->X, counterMap[i]->Y - 1, counterMap[i]->Counter + 1)); //up
		adjacentCells->Add(gcnew PathPoint(counterMap[i]->X + 1, counterMap[i]->Y, counterMap[i]->Counter + 1)); //right
		adjacentCells->Add(gcnew PathPoint(counterMap[i]->X, counterMap[i]->Y + 1, counterMap[i]->Counter + 1)); //down		
		adjacentCells->Add(gcnew PathPoint(counterMap[i]->X - 1, counterMap[i]->Y, counterMap[i]->Counter + 1)); //left

		//for each adjacent cell
		for(int j = 0; j < adjacentCells->Count; j++)
		{
			//if adjacent cell is origin, then pathing is complete. Stop adding points.
			if(adjacentCells[j]->Equals(origin))
			{
				adjacentCells[0] = adjacentCells[j];
				adjacentCells->RemoveRange(1, adjacentCells->Count - 1);
				mapComplete = true;
			}
			//if adjacent cell is not contained in map, remove it as a valid adjacent cell
			else if (!Contains(adjacentCells[j]->X, adjacentCells[j]->Y))
			{
				adjacentCells->RemoveAt(j);
				j--;
			}
			//if adjacent cell is not empty, remove it as a valid adjacent cell
			else if (!Empty(adjacentCells[j]->X, adjacentCells[j]->Y))
			{
				adjacentCells->RemoveAt(j);
				j--;
			}
			else
			{
				//if the adjacent cell is already in the counterMap, remove it as a valid adjacent cell
				for each(PathPoint^ step in counterMap)
				{
					if(adjacentCells[j]->Equals(step))
					{
						adjacentCells->RemoveAt(j);
						j--;
						break;
					}
				}
			}
		}

		//add any remaining valid adjacent cells to the countermap.
		counterMap->AddRange(adjacentCells);
	}

	//if the counterMap did not make it back to the origin, there's no available path. Stahp.
	if(!counterMap[counterMap->Count - 1]->Equals(origin))
	{
		soundFX[1]->controls->play();
		return nullptr;
	}

	//Path is the countermap stripped away of all dead/incomplete ends
	List<PathPoint^>^ path = gcnew List<PathPoint^>();
	path->Add(counterMap[counterMap->Count - 1]); //adds origin
	
	//The Count represents how far away each point is from the destination. 
	//The origin has the largest count. Until the destination's count which is 0) is reached..
	for(int i = counterMap->Count - 2; i >= 0; i--)
	{
		//trace through the countermap, finding a linked path.
		PathPoint^ previous = path[path->Count - 1];
		if(counterMap[i]->Counter == previous->Counter - 1)
		{
			//if the current point we're looking at in countermap is adjacent to the previous one in path..
			if((counterMap[i]->X == previous->X && (counterMap[i]->Y == previous->Y - 1 || counterMap[i]->Y == previous->Y + 1)) || 
				(counterMap[i]->Y == previous->Y && (counterMap[i]->X == previous->X - 1 || counterMap[i]->X == previous->X + 1)))
			{
				//add it to the path.
				path->Add(counterMap[i]);
			}
		}
	}
	return path;
}

///
///Selects/Deselects a cell at the given pixel location.
///
void Grid::HighlightCell(Point^ highlightLocation)
{
	if (state == GameState::Idle)
	{
		//converts the passed in pixel point into grid coordinates
		int highlightCoordinateX = highlightLocation->X / 36;
		int highlightCoordinateY = highlightLocation->Y / 36;

		//if the selected cell is already highlighted, unselect it
		if(selectedCell == currentState[highlightCoordinateX, highlightCoordinateY])
		{
			selectedCell = nullptr;
		}
		//otherwise, the previously selected cell is moved to the newly selected cell
		else
		{
			SwitchCellContent(highlightCoordinateX, highlightCoordinateY);
		}
	}
}

///
/// Swaps the content of the selected cell with that at the given location.
/// ('Animates' a single move.)
///
void Grid::SwitchCellContent(int cellCoordinateX, int cellCoordinateY)
{
	//if there is a selected cell, and it's not empty
	if ((selectedCell != nullptr)&&(selectedCell->Contents != CellContents::Empty))
	{
		//save the contents of the destination cell
		CellContents destinationContents = currentState[cellCoordinateX, cellCoordinateY]->Contents;

		//if the destination cell is empty, do a swap
		if(destinationContents == CellContents::Empty)
		{
			path = FindPath(Point(selectedCell->X, selectedCell->Y), Point(cellCoordinateX, cellCoordinateY));
			if(path != nullptr)
			{
				state = GameState::Animating;
				pathIndex = 1;
				SaveState();
			}
		}
		//otherwise, just deselect the initial cell and select the destination cell without swapping
		else
		{
			selectedCell = currentState[cellCoordinateX, cellCoordinateY];
		}
	}
	//if there isn't already a selected cell, just calm down, set it now.
	else
	{
		selectedCell = currentState[cellCoordinateX, cellCoordinateY];
	}
}

///
/// Grid behaviour that needs to happen each turn. Returns true if the grid is full.
///
bool Grid::Update()
{
	bool gridFull = false;
	int i = 0;
	//if cell content is currently in transition..
	if(state == GameState::Animating)
	{
		soundFX[2]->controls->play();

		//sets the cell at the current path index to have the contents of the selected cell.
		currentState[path[pathIndex]->X,path[pathIndex]->Y]->Contents = selectedCell->Contents;
		selectedCell->Contents = CellContents::Empty;
		selectedCell = currentState[path[pathIndex]->X,path[pathIndex]->Y];
		pathIndex++;
		
		//if a transition has just been completed, set the game state to be idle.
		if(pathIndex >= path->Count)
		{
			state = GameState::Idle;
			//if no lines have been made, do a populate.
			if(DeleteLines(selectedCell) == false)
			{
				for(int i = 0; i < 3; i++)
				{
					gridFull = !PopulateCell();					
				}
			}
			redoState->Clear();
		}
	}
	return gridFull;
}

///
///Saves the current contents of the grid, and the score, as a possible undo.
///
void Grid::SaveState()
{
	//make a copy of the current cells
	array<GridCell^, 2>^ current = gcnew array<GridCell^, 2>(n_columns, n_rows);
	for(int i=0; i < n_columns; i++)
	{
		for(int j=0; j < n_rows; j++)
		{
			current[i, j] = gcnew GridCell(i, j);
			current[i, j]->Contents = currentState[i, j]->Contents;
		}
	}
	//append that copy to undo.
	undoState->Add(current);
	//append the score to the possible undos
	undoScore->Add(score);
}

///
/// Reverts an undo by changing the current state to be that of the last saved redoState.
///
void Grid::Redo()
{
	//if there are redo's available
	if(redoState->Count > 0)
	{
		//append the current state to the undo saves (you've just done an undo. Put it back)
		undoState->Add(currentState);
		//make the current state equal the latest redo save.
		currentState = redoState[redoState->Count - 1];
		//remove that redo save from the top of the redo save list.
		redoState->RemoveAt(redoState->Count - 1);

		//^ do the same with score saves.
		undoScore->Add(score);
		score = redoScore[redoScore->Count - 1];
		redoScore->RemoveAt(redoScore->Count - 1);
	}
}

///
/// Changes the current state to be that of the last saved undoState.
///
void Grid::Undo()
{
	//If there are undo's available (true every turn except the first)
	if(undoState->Count > 0)
	{
		//save the current state as a possible redo
		redoState->Add(currentState);
		//now make the current state equal the last saved undo
		currentState = undoState[undoState->Count - 1];
		//and remove that undo from the top of the undo saves.
		undoState->RemoveAt(undoState->Count - 1);

		//do the same for the score.
		redoScore->Add(score);
		score = undoScore[undoScore->Count - 1];
		undoScore->RemoveAt(undoScore->Count - 1);
	}
}

///
/// Adds contents to an empty cell in the grid. Returns false if there aren't any empty cells.
///
bool Grid::PopulateCell()
{
	List<GridCell^>^ emptyCells = gcnew List<GridCell^>();
	for each(GridCell^ cell in currentState)
	{
		if(cell->Contents == CellContents::Empty)
		{
			emptyCells->Add(cell);
		}
	}

	//if there's atleast one empty cell to populate
	if(emptyCells->Count > 0)
	{
		//randomise the empty cell to be populated.
		int randomCell = random->Next(emptyCells->Count);
		//randomise its contents
		int randomColour = random->Next(6);
		emptyCells[randomCell]->Contents = static_cast<CellContents>(randomColour);

		//check to see if the population resulted in a row being created
		DeleteLines(emptyCells[randomCell]);
		//remove the freshly populated cell 
		emptyCells->RemoveAt(emptyCells->Count - 1);
	}

	return(emptyCells->Count > 0);
}

///
/// Checks for lines of consecutive colours. Deletes lines of size 5 or more.
/// The check ripples out from the given cell.
///
bool Grid::DeleteLines(GridCell^ origin)
{
	bool lineDeleted = false;
	List<GridCell^>^ horizontalCells = gcnew List<GridCell^>();
	List<GridCell^>^ verticalCells = gcnew List<GridCell^>();
	List<GridCell^>^ r2l_diagonalCells = gcnew List<GridCell^>();
	List<GridCell^>^ l2r_diagonalCells = gcnew List<GridCell^>();

	CellContents content = origin->Contents;

	//horizontal check
	////////////////////////////////////
	horizontalCells->Add(origin);
	// Offset represents distance from the origin cell
	int offset = 1;

	//checks the cell directly to the left of the origin:
	//If it's in bounds, and has the same contents as the origin..
	while(Contains(origin->X - offset, origin->Y)
		&& currentState[origin->X - offset, origin->Y]->Contents == content)
	{
		//..add it to the horizontal cell list
		horizontalCells->Add(currentState[origin->X - offset, origin->Y]);
		//and then increment so the next cell to the left will be checked
		offset++;
	}

	//check the cells to the right of the origin
	offset = 1;
	while(Contains(origin->X + offset, origin->Y) && 
		currentState[origin->X + offset, origin->Y]->Contents == content)
	{
		horizontalCells->Add(currentState[origin->X + offset, origin->Y]);
		offset++;
	}

	//vertical check
	/////////////////////////////////
	verticalCells->Add(origin);

	//check above the origin
	offset = 1;
	while(Contains(origin->X, origin->Y - offset) 
		&& currentState[origin->X, origin->Y  - offset]->Contents == content)
	{
		verticalCells->Add(currentState[origin->X, origin->Y  - offset]);
		offset++;
	}

	//check below the origin
	offset = 1;
	while(Contains(origin->X, origin->Y + offset) 
		&& currentState[origin->X, origin->Y  + offset]->Contents == content)
	{
		verticalCells->Add(currentState[origin->X, origin->Y  + offset]);
		offset++;
	}

	//diagonal check
	/////////////////////////////////
	//left to right diagonal
	l2r_diagonalCells->Add(origin);
	offset = 1;
	while(Contains(origin->X - offset, origin->Y - offset) 
		&& currentState[origin->X - offset, origin->Y  - offset]->Contents == content)
	{
		l2r_diagonalCells->Add(currentState[origin->X - offset, origin->Y  - offset]);
		offset++;
	}

	offset = 1;
	while(Contains(origin->X + offset, origin->Y + offset) 
		&& currentState[origin->X + offset, origin->Y  + offset]->Contents == content)
	{
		l2r_diagonalCells->Add(currentState[origin->X + offset, origin->Y  + offset]);
		offset++;
	}
	//right to left diagonal
	r2l_diagonalCells->Add(origin);
	offset = 1;
	while(Contains(origin->X - offset, origin->Y + offset) 
		&& currentState[origin->X - offset, origin->Y  + offset]->Contents == content)
	{
		r2l_diagonalCells->Add(currentState[origin->X - offset, origin->Y + offset]);
		offset++;
	}

	offset = 1;
	while(Contains(origin->X + offset, origin->Y - offset) 
		&& currentState[origin->X + offset, origin->Y  - offset]->Contents == content)
	{
		r2l_diagonalCells->Add(currentState[origin->X + offset, origin->Y - offset]);
		offset++;
	}

	int turnScore = 0;
	//if a horizontal line of 5 or more has been made
	if(horizontalCells->Count >= 5)
	{
		lineDeleted = true;
		//count up how many cells are in it, and clear their contents.
		for each(GridCell^ cell in horizontalCells)
		{
			cell->Contents = CellContents::Empty;
			turnScore++;
		}
	}
	if(verticalCells->Count >= 5)
	{
		lineDeleted = true;
		for each(GridCell^ cell in verticalCells)
		{
			cell->Contents = CellContents::Empty;
			turnScore++;
		}
	}
	if(l2r_diagonalCells->Count >= 5)
	{
		lineDeleted = true;
		for each(GridCell^ cell in l2r_diagonalCells)
		{
			cell->Contents = CellContents::Empty;
			turnScore++;
		}
	}
	if(r2l_diagonalCells->Count >= 5)
	{
		lineDeleted = true;
		for each(GridCell^ cell in r2l_diagonalCells)
		{
			cell->Contents = CellContents::Empty;
			turnScore++;
		}
	}


	//calculate the score for the turn, add to the running score.
	if(lineDeleted)
	{
		soundFX[0]->controls->play();
		score += 500;
		if(turnScore > 5)
		{
			score += (turnScore - 5) * 500;
		}	
	}
	return lineDeleted;
}
