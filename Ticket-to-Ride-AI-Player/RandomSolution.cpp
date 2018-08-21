#include "RandomSolution.h"

RandomSolution::RandomSolution(char *user, char *pass, 
			char *agent, char *host, int port) 
	: TTRClient(user, pass, agent, host, port)
{
	myRand = new TTRGenerator();
}
 
void RandomSolution::myMethod(void)
{
	// Set action performed flag to false as we have not acted this turn.
	actionPerformed = false;
		
	// If (firstMissions==true) reject last received mission.
	if (firstMissions) discardMissions();
	else 	
		// As long as we have not performed an action, attempt to choose an action to perform.
		while ((!actionPerformed)&&(play)&&(myTurn))
		{
			 // Randomly select an action.


			//if i have 4 of any colour in my hand, try to take a route that is 4, and that colour.
				//if i can't, try to take a route that is 4, and grey
					//if i can't, if the open deck has a colour that's already in my hand, pick it up x2
					//otherwise, draw from closed deck.

			
			TTRCard **myCards = myPlayer->getCards(); // Get out player's cards in hand.
			int nWildCards = myCards[8]->getCount(); //counts the number of wildcards in hand
			bool routeClaimed = false;
			TTRCard *currentCard = (TTRCard*)0;
			TTRCard *colorToClaim = (TTRCard*)0;
			for (int i=0; i<nColors-2 && routeClaimed == false; i++) //check to see if the player has four of a kind
			{
				currentCard = myCards[i];
				if((currentCard->getCount() + nWildCards) >= 4)//if player has 4 of a kind..
				{
					int spendWildCards = 4 - currentCard->getCount();
					colorToClaim = currentCard;
					routeClaimed = attemptToClaimColoredRoute(currentCard, spendWildCards);//try to take a route of the same colour. returns true on success.
				}
				else
				{
					currentCard = (TTRCard*)0;
				}
			}
			if(routeClaimed == false && colorToClaim != (TTRCard*)0)//if a route still hasn't been claimed, but there's 4 of a kind..
			{
				int spendWildCards = 4 - colorToClaim->getCount();
				routeClaimed = attemptToClaimNeutralRoute(colorToClaim, spendWildCards);//trys to take a neutral route. returns true on success.
			}
			
			if (routeClaimed == false)
			{
				drawCards();
			}
		}
}

void RandomSolution::discardMissions(){ //keeps biggest, and cheapest
	int ret = 0; //2 = 2 missions rejected, 1 = 1 mission, and 0 = none rejected, < 0 = fail
	ArrayList<TTRMission> *m = myPlayer->getMissionArray();
	
	ArrayList<TTRMission> *orderedMissions = new ArrayList<TTRMission>(); //order missions by ascending value
	orderedMissions->add(m->get(0));
	for(int i=1; i < m->size(); i++) //for each mission
	{
		int currentMissionValue = m->get(i)->getValue();
		int index = 0;
		while(currentMissionValue > orderedMissions->get(index)->getValue())
		{
			index++;
		}
		orderedMissions->add(m->get(i));
	}
	
	while ((ret != 2)&&(play)){
		//keep smallest value missions
		ret = rejectMissions(orderedMissions->get(0), orderedMissions->get(1));
		actionPerformed = true;
	}
}

void RandomSolution::drawCards(){
	if (attemptToDrawFromOpenDeck())//if one card is taken from the open deck..
	{
		if(!attemptToDrawFromOpenDeck())//attempt to take another, if unsuccessful..
		{
			attemptToDrawFromBlindDeck();//draw from blind deck
		}
	}
	else //none taken from open deck: draw twice from blind deck.
	{
		attemptToDrawFromBlindDeck();
		attemptToDrawFromBlindDeck();
	}	
}
//look at deck, if it has any cards that i have from 1 to 3 of, grab them
bool RandomSolution::attemptToDrawFromOpenDeck(){

	TTRDeck<TTRCard> *openDeck = myMap->getOpenDeck();
	for(int i = 0; i < nColors-2; i++)
	{
		if(myPlayer->getCards()[i]->getCount() > 0 && myPlayer->getCards()[i]->getCount() < 4)
		{
			int nOccurances = openDeck->contains(myPlayer->getCards()[i]->getColor());
			if (nOccurances > 0)
			{
				int ret = drawCardFromOpenDeck(myPlayer->getCards()[i]->getColor());
				if (ret == 1){return true;}
			}
		}
	}
	return false;
}

bool RandomSolution::attemptToDrawFromBlindDeck(){
	bool cardDrawn = false;
	// Draw the card.
	int ret = drawCardFromDeck();
	if (ret==1)
	{
		cardDrawn = true;
	}
	return cardDrawn;
}
	
void RandomSolution::attemptToDrawMissions(){
	// Attempt to draw missions.
	int ret = drawMissions();
	if (ret>0)
	{
		// If successful
		ret = 0;
		// While not successful attempt to keep all missions.
		while ((ret != 0)&&(play))
			ret = keepAllMissions();
	}
	// Set actionPerformed flag to true.
	actionPerformed = true;
}
	
bool RandomSolution::attemptToClaimColoredRoute(TTRCard *currentCard, int nWildCards){
	//find all the routes that are 4 edges long, don't have tunnels, don't have trains, and aren't taken, and are the colour i've got four of
	
	// Initialize edge to claim.
	bool routeFound = false;
	TTREdge *edge = (TTREdge *)0; 
	for(int i = 0; i < myMap->getNAdj() && routeFound == false; i++)
	{
		for(int j = 0; j < myMap->getNAdj() && routeFound == false; j++)
		{			
			edge = myMap->getAdj()[i][j];
			if (edge != (TTREdge *)0)
			{
				if(edge->getCars() == 4 && edge->getTunnel() == 0 && edge->getEngines() == 0)
				{
					if((edge->getOwner(0) == (TTRPlayer*)0 && edge->getColor(0) == currentCard->getColor()) || 
						(edge->getOwner(1) == (TTRPlayer*)0 && edge->getColor(1) == currentCard->getColor()))
					{
						int ret = claimRoute(i, j, currentCard->getColor(), currentCard->getCount(), nWildCards);
						routeFound = true;

						if(ret<0)
						{
							routeFound = false;
						}
						else{actionPerformed = true;}
					}
				}
			}
		}
	}
	return routeFound;
}

bool RandomSolution::attemptToClaimNeutralRoute(TTRCard *currentCard, int nWildCards){
	//find all the routes that are 4 edges long, don't have tunnels, don't have trains, and aren't taken

	// Initialize edge to claim.
	bool routeFound = false;
	TTREdge *edge = (TTREdge *)0; 
	for(int i = 0; i < myMap->getNAdj() && routeFound == false; i++)
	{
		for(int j = 0; j < myMap->getNAdj() && routeFound == false; j++)
		{			
			edge = myMap->getAdj()[i][j];
			if (edge != (TTREdge *)0)
			{
				if(edge->getCars() == 4 && edge->getTunnel() == 0 && edge->getEngines() == 0)
				{
					int ret = claimRoute(i, j, currentCard->getColor(), currentCard->getCount(), nWildCards);
					routeFound = true;

					if(ret<0){routeFound = false;}
					else{actionPerformed = true;}
				}
			}
		}
	}
	return routeFound;
}

bool RandomSolution::isClaimed(TTREdge *edge)
{
	for(int i = 0; i < myMap->nPlayers; i++)
	{
		if(edge->getOwner(i) != (TTRPlayer*)0)
		{
			return true;
		}
	}	
	return false;
}


void RandomSolution::attemptToBuildStation(){
	// If we have no stations left, move on
	if (myPlayer->getNStations() == 0) return;
	// Initialize edge to build station on.
	TTREdge *edge = (TTREdge *)0; 
	// Get number of nodes on map.
	int n = myMap->getNAdj();
	// Initialize source and destination nodes.
	int s=0, d=0;
	// Randomly pick an edge.
	while (edge == (TTREdge *)0)
	{
		s = myRand->get()%n; 
		d = myRand->get()%n;
		edge = myMap->getAdj()[s][d];
	}
	// Get number of required cards to build station.
	int req = 4 - myPlayer->getNStations();
	char color = '0'; 
	// Get first card in card array to have enough cards to build station.
	TTRCard **myCards = myPlayer->getCards();
	for (int i=0; i<nColors-1; i++)
	{
		if (myCards[i]->getCount() >= req)
		{
			color = myCards[i]->getColor();
			break;
		}
	}
	// Attempt to build station.
	int ret = buildStation(s, d, color, req, 0);
	// If successful, set actionPerformed flag to true.
	if (ret==1) actionPerformed = true;
}

RandomSolution::~RandomSolution(void){}
