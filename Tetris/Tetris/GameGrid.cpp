#include "StdAfx.h"
#include "GameGrid.h"


GameGrid::GameGrid(Graphics^ graphics)
{
	this->graphics = graphics;
	random = gcnew Random();

	//initialise grid
	grid = gcnew array<Cell^, 2>(N_COLUMNS, N_ROWS);
	for(int i=0; i < N_COLUMNS; i++)
	{
		for(int j=0; j < N_ROWS; j++)
		{
			grid[i, j] = nullptr;
		}
	}
	
	//create spawn zone
	spawnPositionX = N_COLUMNS / 2;
	spawnPositionY = 0;
}

void GameGrid::MoveShape(Direction direction) //turns user input into a direction for cell
{
	if (shapeInFocus != nullptr)
	{
		switch(direction)
		{
			case Direction::Left:
				shapeInFocus->MoveCellsLeft();
				if(OutOfBounds() || Collision())
				{
					shapeInFocus->MoveCellsRight();
				}			
			break;
			case Direction::Right:
				shapeInFocus->MoveCellsRight();
				if(OutOfBounds() || Collision())
				{
					shapeInFocus->MoveCellsLeft();
				}		
			break;
			case Direction::Down:
				while(!OutOfBounds() && !Collision())
				{
					shapeInFocus->Fall();
				}	
				shapeInFocus->DefyGravity();
				AddToGraveyard();
				DeleteCompleteRows();
			break;
			case Direction::Up:
				{
					shapeInFocus->RotateCellsClockwise();
					if(OutOfBounds() || Collision())
					{
						shapeInFocus->RotateCellsAntiClockwise();
					}
				}
			break;
		}
	}
}

bool GameGrid::OutOfBounds()
{
	for each(Cell^ cell in shapeInFocus->GetCells())
	{
		int x = ConvertPositionXToColumn(cell->GetPositionX());
		int y = ConvertPositionYToRow(cell->GetPositionY());
		if((x < 0) || (x >= N_COLUMNS) || (y >= N_ROWS) || (y < 0))
		{
			return true;
		}
	}

	return false;
}

bool GameGrid::Collision()
{
	for each(Cell^ cell in shapeInFocus->GetCells())
	{
		int x = ConvertPositionXToColumn(cell->GetPositionX());
		int y = ConvertPositionYToRow(cell->GetPositionY());
		if(grid[x, y] != nullptr)
		{
			return true;
		}
	}
	return false;
}
void GameGrid::Draw(Graphics^ graphics) //draw falling cell, graveyard cells
{
	if(shapeInFocus != nullptr) {shapeInFocus->DrawCells(graphics);}
	for(int column = 0; column < grid->GetLength(0); column++)
	{
		for(int row = 0; row <grid->GetLength(1); row++)
		{
			if(grid[column, row] != nullptr)
			{
				grid[column, row]->Draw(graphics);
			}
		}
	}
}
void GameGrid::Update() //cell fall, stuff that happens every timer tick
{
	if(shapeInFocus == nullptr)
	{
		SpawnShape();
	}
	else
	{
		shapeInFocus->Fall();
		if(OutOfBounds() || Collision())
		{
			shapeInFocus->DefyGravity();
			AddToGraveyard();
			DeleteCompleteRows();
		}
	}
}

void GameGrid::SpawnShape()
{
	int shapeType = random->Next(7);
	shapeInFocus = gcnew FocusShape(COLUMN_WIDTH, ROW_HEIGHT, ConvertColumnToPositionX(spawnPositionX), ConvertRowToPositionY(spawnPositionY), shapeType);
}

void GameGrid::AddToGraveyard()
{
	for each(Cell^ cell in shapeInFocus->GetCells())
	{
		int x = ConvertPositionXToColumn(cell->GetPositionX());
		int y = ConvertPositionYToRow(cell->GetPositionY());

		grid[x,y] = cell;
		cell->SetColour(Brushes::Bisque);
	}

	shapeInFocus = nullptr;
}

void GameGrid::DeleteCompleteRows()
{
	for(int row = grid->GetLength(1) - 1; row >= 0; row--)
	{
		int nFullCells = 0;
		for(int column = 0; column < grid->GetLength(0); column++)
		{
			if(grid[column, row] != nullptr)
			{
				nFullCells++;
			}
		}
		if(nFullCells == grid->GetLength(0))
		{
			DeleteRow(row);
			row++;
		}
	}
}

void GameGrid::DeleteRow(int row)
{
	for(row; row >= 1; row--)
	{
		for(int column = 0; column < grid->GetLength(0); column++)
		{
			grid[column, row] = grid[column, row - 1];
			if(grid[column, row - 1] != nullptr)
			{
				grid[column, row - 1]->Fall();
			}
		}
	}
}

bool GameGrid::CheckLoseConditions()
{
	//cycle through each column in grid[i, 0]
	//if it doesn't equal nullptr, return true
	for(int column = 0; column < grid->GetLength(0); column++)
	{
		if(grid[column, 0] != nullptr)
		{
			return true;
		}
	}
	return false;
}