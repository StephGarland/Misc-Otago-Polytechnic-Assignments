#include "StdAfx.h"
#include "FocusShape.h"

FocusShape::FocusShape(int cellWidth, int cellHeight, int spawnPositionX, int spawnPositionY, int shapeType)
{
	this->cellWidth = cellWidth;
	this->cellHeight = cellHeight;

	originPositionX = spawnPositionX + (Formations[shapeType][0, 0] * cellWidth);
	originPositionY = spawnPositionY + (Formations[shapeType][1, 0] * cellHeight);

	cells = gcnew array<Cell^>(4);
	for(int i = 0; i < cells->Length; i++)
	{
		int x = spawnPositionX + (Formations[shapeType][i + 1, 0] * cellWidth);
		int y = spawnPositionY + (Formations[shapeType][i + 1, 1] * cellHeight);
		cells[i] = gcnew Cell(x, y, cellWidth, cellHeight);
	}
}

void FocusShape::DrawCells(Graphics^ graphics)
{
	for each(Cell^ cell in cells)
	{
		cell->Draw(graphics);
	}
}
	
void FocusShape::MoveCellsLeft()
{
	for each(Cell^ cell in cells)
	{
		cell->MoveLeft();
	}
	originPositionX -= cellWidth;
}

void FocusShape::MoveCellsRight()
{
	for each(Cell^ cell in cells)
	{
		cell->MoveRight();
	}
	originPositionX += cellWidth;
}

void FocusShape::RotateCellsClockwise()
{
	for each(Cell^ cell in cells)
	{
		cell->RotateClockwise(originPositionX, originPositionY);
	}
}

void FocusShape::RotateCellsAntiClockwise()
{
	for each(Cell^ cell in cells)
	{
		cell->RotateAntiClockwise(originPositionX, originPositionY);
	}
}

void FocusShape::Fall()
{
	for each(Cell^ cell in cells)
	{
		cell->Fall();
	}
	
	originPositionY += cellHeight;
}

void FocusShape::DefyGravity()
{
	for each(Cell^ cell in cells)
	{
		cell->DefyGravity();
	}
	
	originPositionY -= cellHeight;
}
