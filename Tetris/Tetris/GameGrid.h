#pragma once
using namespace System;
using namespace System::Collections::Generic;
#include "FocusShape.h"
#include "Cell.h"

#define N_ROWS 20
#define N_COLUMNS 15
#define COLUMN_WIDTH 20
#define ROW_HEIGHT 20

ref class GameGrid
{
	FocusShape^ shapeInFocus;
	array<Cell^, 2>^ grid;

	Graphics^ graphics;
	Random^ random;

	int spawnPositionX;
	int	spawnPositionY;

public:
	GameGrid(Graphics^ graphics);
	void MoveShape(Direction direction); //turns user input into a direction for cell
	void Draw(Graphics^ graphics); //draw falling cell, graveyard cells
	void Update(); //cell fall, stuff that happens every timer tick
	void AddToGraveyard();
	int ConvertPositionYToRow(int positionY){return positionY / ROW_HEIGHT;};
	int ConvertPositionXToColumn(int positionX){return positionX / COLUMN_WIDTH;};
	int ConvertColumnToPositionX(int column){return column * COLUMN_WIDTH;};
	int ConvertRowToPositionY(int row){	return row * ROW_HEIGHT;};
	void SpawnShape();
	int GetGridWidth(){return N_COLUMNS * COLUMN_WIDTH;};
	int GetSpawnPositionY(){return spawnPositionY;};
	int GetSpawnPositionX(){return spawnPositionX;};
	int GetGridHeight(){return N_ROWS * ROW_HEIGHT;};
	bool CheckLoseConditions();
	void DeleteRow(int row);
	void DeleteCompleteRows();
	bool Collision();
	bool OutOfBounds();
};
