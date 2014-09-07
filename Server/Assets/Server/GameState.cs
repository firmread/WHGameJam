using UnityEngine;
using System.Collections;



public class GameState : MonoBehaviour {
	
//	enum GameStateEnum {
//		preGame, //0
//		hwBaseScreen, //1
//		gameScreen, //2
//		dealScreen, //3
//		voteScreen, //4
//		pointDisplay //5
//	}
//	
//	enum RolesInGame {
//		influencer1,
//		influencer2,
//		lobbyist,
//		voter1,
//		voter2
//	}

	public int maxConnections = 5;
	public int currentGameState = 0;
	private int prevGameState = 0;

	public Player[] players = new Player[5];
	public int[] voteCountOnSide = {0,0,0};


	// Use this for initialization
	void Start () {

	}
	


	// Update is called once per frame
	void Update () {
		//broadcast change
		if (currentGameState != prevGameState) {
			networkView.RPC ("changeState", RPCMode.AllBuffered, currentGameState);
		}

		transform.position = new Vector3 (currentGameState, 0, 0);

		//where we are

		// all connected, still at first game state, everyone is ready
		if (Network.connections.Length == maxConnections && 
		    currentGameState == 0 && 
		    bAllInited()) 
		{
			currentGameState = 1;

			for (int i = 0; i < players.Length; i++){
				networkView.RPC ("AssignRole", RPCMode.AllBuffered, 
				                 Network.connections[i].ipAddress, i );
			}

		} else if (currentGameState == 1) {
			
		} else if (currentGameState == 2) {
	
		} else if (currentGameState == 3) {
	
		} else if (currentGameState == 4) {
	
		} else if (currentGameState == 5) {
			
		} else {
			currentGameState = 0; 
		}

		//update state checker
		prevGameState = currentGameState;

	}

	
	[RPC]
	void AssignRole ( string ip, int _role){

	}




	bool bAllInited (){
		bool bCheck = true;
		for (int i = 0; i < players.Length; i ++) {
			if (players[i].pState < 1) bCheck = false;
		}
		if (bCheck) return true; 
		else return false;
	}


	//server functions
	void DetectPlayerInNetwork(){
		
		for (int i = 0; i < players.Length; i++){
			networkView.RPC("AddTestInt", RPCMode.Server);
		}

	}





}
