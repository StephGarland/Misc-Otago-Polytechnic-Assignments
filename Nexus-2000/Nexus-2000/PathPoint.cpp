#include "StdAfx.h"
#include "PathPoint.h"

///
///	PathPoint contructor: sets initial coordinates and counter.
///
PathPoint::PathPoint(int x, int y, int counter)
{
	X = x;
	Y = y;
	Counter = counter;
}

///
///	PathPoint contructor: sets initial coordinates and counter.
///
PathPoint::PathPoint(Point point, int counter)
{
	X = point.X;
	Y = point.Y;
	Counter = counter;
}

///
///	Checks to see if given coordinates are the same as its own.
/// Accepts a point, returns true if the point is the same as its own coordinates.
///
bool PathPoint::Equals(Point other)
{
	return X == other.X && Y == other.Y;
}

///
///	Checks to see if given PathPoint has the same coordinates as its own.
/// Accepts a Pathpoint, returns true if the point has the same coordinates as its own.
///
bool PathPoint::Equals(PathPoint^ other)
{
	return X == other->X && Y == other->Y;
}
