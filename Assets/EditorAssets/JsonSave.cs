using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class JsonSave : MonoBehaviour {

	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

	}

    int n = 0;

    public void InfoRecieve(List<string> information, GameObject thisObject, GameObject connection, GameObject snapPoint, string jsonName){
        JsonObject json = new JsonObject();
        json.pointName = thisObject.name;
        if(connection != null)
            json.connection = connection.name;
        if(snapPoint != null)
            json.snapPoint = snapPoint.name;
        float[] position = { thisObject.transform.position.x, thisObject.transform.position.y };
        json.position = position;
        JsonRecieve(JsonUtility.ToJson(json, true), jsonName);
    }

    string fullJsonFile = "{\n\"Points\" : [ \n";

    public void JsonRecieve(string json, string jsonName) {
        fullJsonFile += json;
        n++;
        if (n < GameObject.FindGameObjectsWithTag("Point").Length)
            fullJsonFile += ",\n";
        else {
            fullJsonFile += "\n]\n}";
            File.WriteAllText(Application.dataPath + "/Saves/" + jsonName + ".json", fullJsonFile);
            fullJsonFile = "{\n\"Points\" : [ \n";
            n = 0;
        }
    }
}

[System.Serializable]
public class JsonObject {
    public string pointName = "";
    public string teacher = "";
    public string lesson = "";
    public float[] position;
    public string connection;
    public string snapPoint;
}
