#pragma strict

private var addPoint : boolean = false;
private var addLink : boolean = false;
public var points : Transform;

function Start () {

}

function Update () {
	if(Input.GetMouseButtonDown(0) && addPoint == true){
		Instantiate(points, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f), transform.rotation);
	}
	else if(Input.GetMouseButtonDown(0) && addLink == true){
		Instantiate(points, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f), transform.rotation);
	}
}

function OnAddClick(){
	yield WaitForSeconds(0.02f);
	addPoint = true;
}

function OnLinkClick(){
	yield WaitForSeconds(0.02f);
	addLink = true;
}