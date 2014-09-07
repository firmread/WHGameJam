//#pragma strict
//enum GameState {
//	preGame,
//	hwBaseScreen,
//	gameScreen,
//	dealScreen,
//	voteScreen,
//	pointDisplay
//};
//enum RolesInGame {
//	influencer1,
//	influencer2,
//	lobbyist,
//	voter1,
//	voter2
//};
//
//var pVC = new Array ();
//int pPoint[5];
//int role[5];
//boolean bInited[5];
//var currentGameState = preGame;
////boolean bHWDone[5];
//
//
//
//function Start () {
//
//}
//
//function Update () {
//
//	//all players ready to play
//	if (Network.connections.Length == 5 &&
//	bInited[0] && bInited[1] && bInited[2] && bInited[3] && bInited[4]){
//		
//	}
//	
//	
//	
//}
//
//// INIT Players
//@RPC
//function InitPlayer ( playerNo : int, point : int, vc : int){
//	pVC[playerNo] = vc;
//	pPoint[playerNo] = point;
//	bInited[playerNo] = true;
//}
//
////
//function HWChoice ( playerNo : int, mult : float, eventFlag : int){
//	pVC[playerNo] *= mult;
//	bHWDone[playerNo] = true;
//}