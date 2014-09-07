using UnityEngine;
using System.Collections;

public class myRole : MonoBehaviour {

	private int role = -1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	[RPC]
	void AssignRole ( string ip, int _role){
		if (ip == Network.player.ipAddress) role = _role;
	}

	void Vote (int role, int side, int voteCount){

	}



}
