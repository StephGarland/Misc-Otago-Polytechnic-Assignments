#pragma once
#include "GridCell.h"
#include "PathPoint.h"
using namespace System;
using namespace System::Drawing;
using namespace System::Collections::Generic;
using namespace System::Windows::Forms;

///Enum describing whether the game is animating, or idle (ready to act on user input)
enum class GameState
{
	Idle,
	Animating
};

///
/// The Grid class: the board on which the game takes place.
///
ref class Grid
{
	literal int CELL_SIZE = 36;
	literal int n_columns = 9;
	literal int n_rows = 9;

	array<WMPLib::WindowsMediaPlayer^>^ soundFX;
	array<Image^>^ images;
	array<GridCell^, 2>^ currentState;
	List<array<GridCell^, 2>^>^ undoState;
	List<array<GridCell^, 2>^>^ redoState;
	List<int>^ undoScore;
	List<int>^ redoScore;

	Pen^ whitePen;
	List<PathPoint^>^ path;
	int turnCounter;
	int score;
	int pathIndex;
	GameState state;
	GridCell^ selectedCell;
	Random^ random;


public:
	Grid(array<WMPLib::WindowsMediaPlayer^>^ soundFX); //Grid constructor: requires an array of sounds effects, sets initial data member values.
	bool Update(); // Grid behaviour that needs to happen each turn. Returns true if the grid is full.
	void Draw(Graphics^ graphics); //Draws the most current grid setup (including contents and highlighting of selected cell)
	bool Contains(int x, int y); //Accepts coordinates, returns true if the coordinates are within the grid bounds.
	bool Empty(int x, int y); //Accepts coordinates, returns true if the cell at that position is empty.
	int GetNEmptyCells(); //Returns a count of the cells that are empty
	bool PopulateCell(); // Adds contents to an empty cell in the grid. Returns false if there aren't any empty cells.
	void SaveState(); //Saves the current contents of the grid, and the score, as a possible undo.
	void Redo(); // Reverts an undo by changing the current state to be that of the last saved redoState.
	void Undo(); // Changes the current state to be that of the last saved undoState.
	bool DeleteLines(GridCell^ selectedCell); // Checks for lines of consecutive colours. Deletes lines of size 5 or more.
	void SwitchCellContent(int cellCoordinateX, int cellCoordinateY); // Swaps the content of the selected cell with that at the given location.
	List<PathPoint^>^ FindPath(Point origin, Point destination); //Returns a list of pathpoints between two given points.
	void HighlightCell(Point^ highlightLocation); //Selects/Deselects a cell at the given pixel location.

	//Grid accessors
	int GetScore(){return score;};
};
