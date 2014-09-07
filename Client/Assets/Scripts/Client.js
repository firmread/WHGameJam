#pragma strict

/* Server ip address, now we use localhost ip */
var serverIpAddress = "127.0.0.1";
/* Server port address */
var serverPort = 27001;

/**
 * This Function handing to connection
 */
function ConnectToServer(){
	Network.Connect(serverIpAddress, serverPort);
}


/**
 * This Function handing to disconnection
 */
function DisconnectToServer(){
	Network.Disconnect();
}

/**
 * OnGUI is called for rendering and handling GUI events.
 */
function OnGUI (){   
    if (Network.peerType == NetworkPeerType.Disconnected){  
    
     	/* Client is not connected to server */ 
        GUILayout.Label("Disconnected");
        if (GUILayout.Button("Connect")) {
            ConnectToServer();
        }                 
    } else {
        if(Network.peerType == NetworkPeerType.Connecting) {
            GUILayout.Label("Connecting");
        }else {
            GUILayout.Label("Connected");
        }
        if (GUILayout.Button("Disconnect"))
            DisconnectToServer();
        if (GUILayout.Button("testInt ++"))
            networkView.RPC("AddTestInt", RPCMode.Server);
            
            
    }
}

@RPC
function AddTestInt(){
}


/**
 * Called on the client when the connection was lost or you disconnected from the server.
 */
function OnDisconnectedFromServer (aInfo : NetworkDisconnection) {
    var objects : GameObject[] = GameObject.FindGameObjectsWithTag("Player");
    for(var object : GameObject in objects) {
    Debug.Log(object);
        Destroy(object);
    }
}

/**
 * Update
 */
function Update() {
    if (Input.anyKey) {
	    var y: float = Input.GetAxis("Vertical");
	    var x: float = Input.GetAxis("Horizontal");
	    
	    if ((y!=0) || (x!=0)) {
	        networkView.RPC("MoveObject", RPCMode.Server, Network.player, y, x);
	    }
    }
}

@RPC
function MoveObject(aPlayer: NetworkPlayer, aY: float, aX: float) {
}