#pragma strict

/* Server port address */
var portNumber = 27001;
/* Maximun numbers of client */
var maxConnections = 10;
var testInt =0;
/**
 * This function will start game server
 */
function StartServer(){
	Network.InitializeServer(maxConnections, portNumber, false);
}

/**
 * This function will stop game server
 */
function StopServer(){
	Network.Disconnect();
}

/**
 * OnGUI is called for rendering and handling GUI events.
 */
function OnGUI (){

 	if (Network.peerType == NetworkPeerType.Disconnected) {
 		/* Server is not started */
 		
        GUILayout.Label("Game server Offline");
        if (GUILayout.Button("Start Game Server")) {				
			StartServer();	
		}
    } else {
    	/* Server is started */
    	
    	if (Network.peerType == NetworkPeerType.Connecting) {
        	GUILayout.Label("Server Starting");
        } else { 
        	GUILayout.Label("Game Server Online");        	
			GUILayout.Label("Server Ip: " + Network.player.ipAddress + " Port: " + Network.player.port);
			GUILayout.Label("Clients: " + Network.connections.Length + "/" + maxConnections);
			
			GUILayout.Label("testInt = " + testInt);
			
			
			/* Get information of connected clients*/
	 		for(var client: NetworkPlayer in Network.connections) {
				GUILayout.Label("Client " + client);	
			}
        }
        if (GUILayout.Button ("Stop Server")){				
			StopServer();	
		}
    }
}


@RPC
function AddTestInt(){
	testInt++;
}

@script RequireComponent(Manager)

private var manager : Manager;

/**
 * Awake is called when the script instance is being loaded.
 */
function Awake() {
    manager = gameObject.GetComponent(Manager);
}
/**
 * Called on the server whenever a new player has successfully connected.
 */ 
function OnPlayerConnected(aPlayer: NetworkPlayer) { 
    manager.NewPlayer(aPlayer);
}

/**
 * Called on the server whenever a player disconnected from the server.
 */ 
function OnPlayerDisconnected(aPlayer : NetworkPlayer) {
    manager.DeletePlayer(aPlayer);
}