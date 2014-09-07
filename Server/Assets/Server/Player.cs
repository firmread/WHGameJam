using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static Player instance;

	public int role;
	public int pVC;
	public int pPoint;
	public int pState = 0;

	private string myIp = "127.0.0.1";
	// Use this for initialization

	void  OnSerializeNetworkView ( BitStream stream ,   NetworkMessageInfo info  ){
		
		if (stream.isWriting) {
			Vector3 pos = new Vector3();
			Vector3 sca = new Vector3();
			pos = transform.position;
			sca = transform.localScale;
			stream.Serialize (ref pos);
			stream.Serialize (ref sca);
		} else if (stream.isReading){
			// Receiving
			Vector3 pos = new Vector3();
			Vector3 sca = new Vector3();
			stream.Serialize(ref pos);
			transform.position = pos;
			stream.Serialize (ref sca);
			transform.localScale = sca;
		}
	}





	void Awake(){
		instance = this;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.localPosition = new Vector3 (role, pVC, pPoint);
		transform.localScale = new Vector3 (pState, 0, 0);


		//preGame
		if (pState > 1) {
			myIp = Network.player.ipAddress;
			if(myIp != "127.0.0.1") {
				pState = 1;
			}
		} 
		else if (pState == 1){

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


//	void updateMyPlayerData(){
//		networkView.RPC("syncPlayerData", RPCMode.AllBuffered,
//		                role, pVC, pPoint, bInited, bHWDone, bSpeechDone, bDealDone, bVoteDone );
//	}

//	[RPC] 
//	void syncPlayerData(int role, int pVC, int pPoint,
//	                    bool bInited, bool bHWDone, bool bSpeechDone, bool bDealDone, bool bVoteDone){
//		
//
//	}





}
