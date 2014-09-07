#pragma strict

var portNumber = 27001;
var maxConnections = 5;

var testInt = 0;

// Use this for initialization
function StartServer()
{
	Network.InitializeServer (maxConnections,portNumber,false);
}
function StopServer()
{
	Network.Disconnect();
}
function OnGUI()
{

 	if (Network.peerType == NetworkPeerType.Disconnected) {
 		/* Server is not started */
 		
        GUILayout.Label("Game server Offline");
        if (GUILayout.Button("Start Game Server")) {				
			StartServer();	
		}
    } 
    else {
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

function Awake(){
    manager = gameObject.GetComponent(Manager);
}

function OnPlayerConnected(aPlayer: NetworkPlayer) { 
    manager.NewPlayer(aPlayer);
}

function OnPlayerDisconnected(aPlayer : NetworkPlayer) {
    manager.DeletePlayer(aPlayer);
}
