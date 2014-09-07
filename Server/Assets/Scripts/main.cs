
using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {


	private int portNumber = 27001;
	public int maxConnections = 5;

	private int testInt = 0;

	// Use this for initialization
	void  StartServer (){
		Network.InitializeServer (maxConnections,portNumber,false);
	}
	void  StopServer (){
		Network.Disconnect();
	}
	void  OnGUI (){

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
		 		foreach(NetworkPlayer client in Network.connections) {
					GUILayout.Label("Client " + client);	
				}
	        }
	        if (GUILayout.Button ("Stop Server")){				
				StopServer();	
			}
	    }
	}



	[RPC]
	void  AddTestInt (){
		testInt++;
	}



}