#pragma once
using namespace System::Drawing;

///
///The PathPoint class: represents one point in a path
///
ref class PathPoint
{
public:
	//PathPoint contructors: sets initial coordinates and counter.
	PathPoint(int x, int y, int counter);
	PathPoint(Point point, int counter);

	//checks to see if another point is the same as itself
	bool Equals(Point other);
	bool Equals(PathPoint^ other);

	//the x,y grid coordinates of the point
	property int X;
	property int Y;

	//how many steps away from the path origin this point is
	property int Counter;
};
