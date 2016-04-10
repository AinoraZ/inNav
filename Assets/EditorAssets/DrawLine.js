#pragma strict

var target : GameObject;
private var line : LineRenderer;

function Start(){
	line = this.GetComponent.<LineRenderer>();
}

function Update () {
	var p1 : Vector3 = gameObject.transform.position;
    var p2 : Vector3 = target.transform.position;
        
    p1.z = 1;
    p2.z = 1;
        
    line.SetPosition(0, p1);
    line.SetPosition(1, p2);

	var distance : float = Vector2.Distance(transform.position, target.transform.position);
		
	line.material.mainTextureScale = new Vector2(distance, 1);
	line.sortingOrder = 10;

}

function FixedUpdate () {
}