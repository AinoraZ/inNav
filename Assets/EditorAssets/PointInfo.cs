using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointInfo : MonoBehaviour {

    void Start () {

	}

    public List<string> information;
	public GameObject connection = null;
    public GameObject snapPoint = null;
    public List <GameObject> connections;

    // Update is called once per frame

    public void SnappedOn(GameObject snap) {
        snapPoint = snap;
    }

    void SaveStart(string jsonPath) {
        GameObject.Find("Main Camera").GetComponent<JsonSave>().InfoRecieve(information, gameObject, connection, snapPoint, jsonPath);
    }

}
