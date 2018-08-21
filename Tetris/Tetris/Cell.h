#pragma once
using namespace System;
using namespace System::Drawing;

enum class Direction
{
	Left,
	Right,
	Down,
	Up
};

ref class Cell
{
	int blockSizeX;
	int blockSizeY;
	int positionX;
	int positionY;
	Brush^ brush;

public:
	Cell(int positionX, int positionY, int blockSizeX, int blockSizeY);
	void Draw(Graphics^ graphics);
	void MoveLeft();
	void MoveRight();
	void Fall();
	void DefyGravity();
	void RotateClockwise(int originX, int originY);
	void RotateAntiClockwise(int originX, int originY);
	int GetPositionY(){return positionY;};
	int GetPositionX(){return positionX;};
	void SetColour(Brush^ brush){this->brush = brush;};

};
