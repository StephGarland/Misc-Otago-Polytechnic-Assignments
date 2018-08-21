#include "StdAfx.h"
#include "GridCell.h"

///
/// Constructor: sets the initial coordinate values and contents of the cell.
///
GridCell::GridCell(int x, int y)
{
	X = x;
	Y = y;
	Contents = CellContents::Empty;
}