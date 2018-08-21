#pragma once
#include "Cell.h"
using namespace System::Collections::Generic;
//create a block object that contains multiple cells?
	//- like, a cell co-ordinator class
	//- so, the grid calls shape methods, which triggers its minions to take care of themselves.

ref class FocusShape
{
private:
	static array<array<int, 2>^>^ Formations = gcnew array<array<int, 2>^>
	{
		{ // Long
			{0, 2},
			{0, 0},
			{0, 1},
			{0, 2},
			{0, 3}
		},
		{ // Square
			{1, 1},
			{0, 0},
			{0, 1},
			{1, 0},
			{1, 1}
		},
		{ // J
			{1, 2},
			{1, 0}, 
			{1, 1}, 
			{0, 2}, 
			{1, 2}
		},
		{ // L
			{1, 2},
			{0, 0},
			{0, 1},
			{0, 2},
			{1, 2}
		},
		{ // T
			{1, 1},
			{0, 0},
			{1, 0},
			{2, 0},
			{1, 1}
		},
		{ // S
			{1, 1},
			{1, 0},
			{2, 0},
			{0, 1},
			{1, 1}
		},
		{ // Z
			{1, 1},
			{0, 0},
			{1, 0},
			{1, 1},
			{2, 1}
		}
	};
	array<Cell^>^ cells;
	int originPositionX;
	int originPositionY;
	int cellWidth;
	int cellHeight;
public:
	FocusShape(int cellWidth, int cellHeight, int spawnPositionX, int spawnPositionY, int shapeType);
	void DrawCells(Graphics^ graphics);
	void MoveCellsLeft();
	void MoveCellsRight();
	void RotateCellsClockwise();
	void RotateCellsAntiClockwise();
	void Fall();
	array<Cell^>^ GetCells(){return cells;};
	void DefyGravity();
};
