using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour {
	

	public string serverIpAddress = "127.0.0.1";
	private int serverPort = 27001;
	public int maxConnections = 5;

	private bool bSelfConnected = false;
	// be server
//	void  StartServer (){
//		Network.InitializeServer (maxConnections,serverPort,false);
//	}
//	void  StopServer (){
//		Network.Disconnect();
//	}

	//be client
	void  ConnectToServer (){
		Network.Connect(serverIpAddress, serverPort);
	}

	void  DisconnectToServer (){
		Network.Disconnect();
	}



	void  OnGUI (){   
		//not connected and no server
		if (Network.peerType == NetworkPeerType.Disconnected){  
			GUILayout.Label("Disconnected");

			GUILayout.Space(100);
			GUILayout.BeginHorizontal ();
			serverIpAddress = GUILayout.TextField (serverIpAddress);
			GUILayout.Label ("IP Address");
			GUILayout.EndHorizontal ();
			
//			GUILayout.BeginHorizontal ();
//			string tempPort;
//			tempPort = GUILayout.TextField (serverPort.ToString());
//			serverPort = int.Parse(tempPort);
//			GUILayout.Label ("Port");
//			GUILayout.EndHorizontal();
			
			if(GUILayout.Button ("Connect")) {
				ConnectToServer();
			}
			//or should i run the server?
//			GUILayout.Space(100);
//			if(GUILayout.Button ("Start Server")) {
//				StartServer();
//			}


			/* Client is not connected to server */ 
		} else {

			if(Network.peerType == NetworkPeerType.Connecting) {
				GUILayout.Label("Server Starting");

			}
			else {
				GUILayout.Label("Connected");
				bSelfConnected = true;
			}

			if (GUILayout.Button("Disconnect"))
				DisconnectToServer();
			if (GUILayout.Button("testInt ++"))
				networkView.RPC("AddTestInt", RPCMode.Server);
			
			
		}
	}

	


	[RPC]
	void  AddTestInt (){

	}
	
	
/**
 * Called on the client when the connection was lost or you disconnected from the server.
 */
	void  OnDisconnectedFromServer ( NetworkDisconnection aInfo  ){
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject obj in objs) {
			Debug.Log(obj);
			Destroy(obj);
		}
	}




/**
 * Update
 */
	void  Update (){

	}

	[RPC]
	void syncPlayerData(int role, int pVC, int pPoint,
	                    bool bInited, bool bHWDone, bool bSpeechDone, bool bDealDone, bool bVoteDone){
		
		
	}



//		networkView.RPC("MoveObject", RPCMode.Server, Network.player, y, x);
	
	
//	[RPC]
//	void  MoveObject ( NetworkPlayer aPlayer ,   float aY ,   float aX  ){
//	}
}