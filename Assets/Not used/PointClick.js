#pragma strict

function Start () {

}

public var sizeAdjustment : float = 0.5f;

function Update () {
	var mPos : Vector2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	var distance : float = Vector2.Distance(mPos, new Vector2(transform.position.x, transform.position.y));
	if(Input.GetMouseButtonDown(0) && distance <= sizeAdjustment ){
	}
}