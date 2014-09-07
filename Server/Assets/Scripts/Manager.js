#pragma strict

var players = new Hashtable();

function NewPlayer(aPlayer : NetworkPlayer) {
    var player : Player = GameObject.FindObjectOfType(Player);
    var object : GameObject = Network.Instantiate(player.cubePrefab, Vector3.up*2, Quaternion.identity, 0);
    players[aPlayer] = object;
}

function DeletePlayer(aPlayer : NetworkPlayer) {

    var object : GameObject = players[aPlayer];
    Network.RemoveRPCs(object.networkView.viewID); 
    Network.Destroy(object); 
    players.Remove(aPlayer); 
}

@RPC
function MoveObject(aPlayer: NetworkPlayer, aY: float, aX: float) {
    var object : GameObject = players[aPlayer];
    
    object.transform.position = object.transform.position + Vector3.right*aX;
    object.transform.position = object.transform.position + Vector3.forward*aY;
}