#include "StdAfx.h"
#include "GameCoordinator.h"

///
/// The GameCoordinator Class: Creates game objects, bosses 'em about a bit.
/// Provides the script for a game turn
///

///
///The game coordinator contructor: requires an array of sounds effects, creates a grid.
///
GameCoordinator::GameCoordinator(array<WMPLib::WindowsMediaPlayer^>^ soundFX)
{
	grid = gcnew Grid(soundFX);
}

///
/// Enacts how the game should be in the first turn
///
void GameCoordinator::Start()
{
	grid->PopulateCell();
	grid->PopulateCell();
	grid->PopulateCell();
}

///
/// Prompts the game objects to draw themselves. Requires a graphics object.
///
void GameCoordinator::Draw(Graphics^ graphics)
{
	grid->Draw(graphics);
}

///
/// Reads in the all-time highest score from a text file.
///
int GameCoordinator::ReadScore()
{
	int highestScore = 0;
	StreamReader^ reader = gcnew StreamReader("highestScore.txt");
	String^ line = reader->ReadLine();
	reader->Close();
	highestScore = Convert::ToInt32(line);
	return highestScore;
}

///
/// If the highest score has been beaten, overwrites it with the new high score.
///
void GameCoordinator::WriteScore(int score)
{
	if(score > ReadScore())
	{
		StreamWriter^ writer = gcnew StreamWriter("highestScore.txt");
		writer->WriteLine(score.ToString());
		writer->Close();
	}

}

///
/// Re-does the player's last undo
///
void GameCoordinator::Redo()
{
	grid->Redo();
}

///
/// Un-does the player's last move.
///
void GameCoordinator::Undo()
{
	grid->Undo();
}

///
/// Represents a game turn. Returns true when game is over.
///
bool GameCoordinator::Update()
{
	bool gameOver = grid->Update();
	if (gameOver)
	{
		WriteScore(GetScore());
	}
	return gameOver;
}

///
/// Passes along a given pixel location.
///
void GameCoordinator::ClickLocation(Point^ clickLocation)
{
	//check click is valid, if it is, find and remember path to that point, enter the animating state
	grid->HighlightCell(clickLocation);
}
