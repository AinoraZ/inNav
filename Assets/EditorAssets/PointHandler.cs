using UnityEngine;
using System.Collections;

public class PointHandler : MonoBehaviour {

    private bool addPoint = false;
    private bool addLink  = false;
    private bool isLocked;
    public GameObject points;

    void Start(){

    }

    private Vector3 mouseWorldSpace;

    void Update(){
        mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && addPoint == true)
        {
            addPoint = false;
            Instantiate(points, new Vector3(mouseWorldSpace.x, mouseWorldSpace.y, 0f), transform.rotation);
        }
        else if (Input.GetMouseButtonDown(0) && addLink == true)
        {
            addLink = false;
            Instantiate(points, new Vector3(mouseWorldSpace.x, mouseWorldSpace.y, 0f), transform.rotation);
        }
    }

    void OnAddClick()
    {
        addPoint = true;
    }

    GameObject[] len;

    void OnLinkClick(GameObject target){
        var link = Instantiate(points, new Vector3(mouseWorldSpace.x, mouseWorldSpace.y, 0f), transform.rotation) as GameObject;
        len = GameObject.FindGameObjectsWithTag("Point");
        bool pointWithNameFound = false;
        for (int x = 0; x < len.Length; x++){
            for (int z = 0; z < len.Length; z++){
                if (GameObject.FindGameObjectsWithTag("Point")[z].name == ("Point" + (x + 1))){
                    pointWithNameFound = true;
                }
            }
            if (!pointWithNameFound)
            {
                link.name = "Point" + (x + 1);
            }
            pointWithNameFound = false;
        }
        DrawLine liner = link.GetComponent<DrawLine>();
        liner.target = target;
    }
}
