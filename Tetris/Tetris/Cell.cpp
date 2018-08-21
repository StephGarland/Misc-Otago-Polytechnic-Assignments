#include "StdAfx.h"
#include "Cell.h"

Cell::Cell(int positionX, int positionY, int blockSizeX, int blockSizeY)
{
	this->positionX = positionX;
	this->positionY = positionY;
	this->blockSizeX = blockSizeX;
	this->blockSizeY = blockSizeY;
	brush = Brushes::LawnGreen;
	positionY = 0;
}

void Cell::Draw(Graphics^ graphics)
{
	graphics->FillRectangle(brush, positionX, positionY, blockSizeX, blockSizeY);
	//graphics->DrawLine(Pens::Black, positionX, positionY, positionX + blockSizeX, positionY);
	//graphics->DrawLine(Pens::Black, positionX + blockSizeX, positionY, positionX + blockSizeX, positionY + blockSizeY);
	//graphics->DrawLine(Pens::Black, positionX + blockSizeX, positionY + blockSizeY, positionX, positionY + blockSizeY);
	//graphics->DrawLine(Pens::Black, positionX, positionY, positionX, positionY + blockSizeY);
}

void Cell::MoveLeft()
{
	positionX -= blockSizeX;
}

void Cell::MoveRight()
{
	positionX += blockSizeX;
}

void Cell::RotateClockwise(int originX, int originY)
{
	//to unify the rotation equation, act as if the cell origin point were at [0,0]
	
	//find the "distance" between the cell position and the origin/shape center point
	float translatedPositionX = positionX - originX;
	float translatedPositionY = positionY - originY;

	//rotate:
	//(cells X location in relation to origin) * Cos(90 degrees) - (cells y location in relation to origin) * Sin(90 degrees)
	float rotatedX = translatedPositionX * Math::Cos(Math::PI / 2) - translatedPositionY * Math::Sin(Math::PI / 2);
	float rotatedY = translatedPositionX * Math::Sin(Math::PI / 2) + translatedPositionY * Math::Cos(Math::PI / 2);

	//apply the hypothetical rotation to real positions


	positionX = (int)rotatedX + originX;
	positionY = (int)rotatedY + originY;
}

void Cell::RotateAntiClockwise(int originX, int originY)
{
	//to unify the rotation equation, act as if the cell origin point were at [0,0]
	
	//find the "distance" between the cell position and the origin/shape center point
	float translatedPositionX = positionX - originX;
	float translatedPositionY = positionY - originY;

	//rotate:
	//(cells X location in relation to origin) * Cos(270 degrees (converted to radians)) - (cells y location in relation to origin) * Sin(270 degrees (converted to radians))
	float rotatedX = translatedPositionX * Math::Cos((270 * Math::PI) / 180) - translatedPositionY * Math::Sin((270 * Math::PI) / 180);
	float rotatedY = translatedPositionX * Math::Sin((270 * Math::PI) / 180) + translatedPositionY * Math::Cos((270 * Math::PI) / 180);

	//apply the hypothetical rotation to real positions


	positionX = (int)rotatedX + originX;
	positionY = (int)rotatedY + originY;
}

void Cell::Fall()
{
	positionY += blockSizeY;
}

void Cell::DefyGravity()
{
	positionY -= blockSizeY;
}
		   
