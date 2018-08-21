#pragma once
using namespace System::Drawing;

///Enum that contains the possible contents that a gridcell can have.
enum class CellContents
{
	Blue = 0,
	Green,
	Red,
	Purple,
	Yellow,
	Aqua,
	Empty
};

///The GridCell class: represents one cell of a grid
ref class GridCell
{
public:
	property CellContents Contents;
	//the coordinate location of the cell
	property int X;
	property int Y;
	//Constructor: sets the initial coordinate values and contents of the cell.
	GridCell(int x, int y);
};
