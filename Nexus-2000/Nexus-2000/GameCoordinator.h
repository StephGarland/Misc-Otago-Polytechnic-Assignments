#pragma once
using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Collections::Generic;
using namespace System::IO;
#include "Grid.h"
#include "GridCell.h"

///Grid size definitions.
#define N_ROWS 9
#define N_COLUMNS 9
#define COLUMN_WIDTH 20
#define ROW_HEIGHT 20

///
/// The GameCoordinator Class: Creates game objects, bosses 'em about a bit.
/// Provides the script for a game turn
///
ref class GameCoordinator
{
	Grid^ grid;

public:

	GameCoordinator(array<WMPLib::WindowsMediaPlayer^>^ soundFX); //The game coordinator contructor: requires an array of sounds effects, creates a grid.
	void Draw(Graphics^ graphics); // Prompts the game objects to draw themselves. Requires a graphics object.
	bool Update(); // Represents a game turn. Returns true when game is over.
	void Undo(); // Un-does the player's last move.
	void Redo(); // Re-does the player's last undo
	int ReadScore(); // Reads in the all-time highest score from a text file.
	void WriteScore(int score); // If the highest score has been beaten, overwrites it with the new high score.
	void Start(); // Enacts how the game should be in the first turn
	void ClickLocation(Point^ clickLocation); // Passes along a given pixel location.

	//GameCoordinator accessors:
	int GetScore(){return grid->GetScore();}; 
};
