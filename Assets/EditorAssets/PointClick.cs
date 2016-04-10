using UnityEngine;
using System.Collections;

public class PointClick : MonoBehaviour {

	void Start () {
	
	}

    public float sizeAdjustment = 0.8f;

    void Update () {
        if (Input.GetMouseButtonDown(0)){
            if (DistanceCalculation() <= sizeAdjustment){
                Debug.Log(gameObject.name + " has been clicked");
            }
        }
    }

    float DistanceCalculation(){
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mPos = new Vector2(mouseWorldSpace.x, mouseWorldSpace.y);

        return Vector2.Distance(mPos, new Vector2(transform.position.x, transform.position.y));
    }
}
