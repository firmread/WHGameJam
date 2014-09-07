using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static Player instance;

	public int role;
	public int pVC;
	public int pPoint;
	public bool bInited = false;
	public bool bHWDone = false;
	public bool bSpeechDone = false;
	public bool bDealDone = false;
	public bool bVoteDone = false;

	private string myIp = "127.0.0.1";
	// Use this for initialization

	void Awake(){
		instance = this;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Network.

		if (!bInited) {
			myIp = Network.player.ipAddress;
			if(myIp != "127.0.0.1") {
				bInited = true;

			}
		} 
		else if (!bHWDone){

		}
	}

	
	
	//preGame
	
	
	//hwBaseScreen
	[RPC]
	void PlayerVCMul ( float mul ){
		pVC = (int) (pVC * mul);
	}
	
	//gameScreen
	//dealScreen
	//voteScreen
	[RPC]
	void progressTimed (string functionName, float minutes){
		Invoke (functionName, minutes);
	}
	//pointDisplay
	
	
	void updateMyPlayerData(){
		networkView.RPC("syncPlayerData", RPCMode.AllBuffered,
		                role, pVC, pPoint, bInited, bHWDone, bSpeechDone, bDealDone, bVoteDone );
	}
	
	[RPC] 
	void syncPlayerData(int role, int pVC, int pPoint,
	                    bool bInited, bool bHWDone, bool bSpeechDone, bool bDealDone, bool bVoteDone){
		
		
	}
	
	
	
	
	
}






}
