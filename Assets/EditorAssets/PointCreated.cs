using UnityEngine;
using System.Collections;

public class PointCreated : MonoBehaviour {

	void Start () {

	}

    public bool isLocked = false;
    public GameObject sendTarget;

    void Update () {
        if (!isLocked && sendTarget != null){
            DrawLine liner = sendTarget.GetComponent<DrawLine>();
            liner.target = gameObject;
        }
        if (!isLocked){
            Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldSpace.x, mouseWorldSpace.y, 0f);
        }
        if (Input.GetMouseButtonDown(0)){
            isLocked = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !isLocked){
            Destroy(gameObject);
        }
    }

    bool off = false;

    void OnLinkClick(GameObject clicked){
        if (!off){
            off = true;
            isLocked = true;
            GetComponent<PointInfo>().SnappedOn(clicked);
            transform.position = clicked.transform.position;
            gameObject.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 100f));
            gameObject.GetComponent<DrawLine>().enabled = false;
            gameObject.GetComponent<PointClick>().enabled = false;
            gameObject.GetComponent<PointCreated>().enabled = false;
        }
    }
}
