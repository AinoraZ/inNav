using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Open : MonoBehaviour {

    public GameObject point;
    List <GameObject> gPoints;

    public void OpenNew(List <JsonOpen> points){
        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++) {
            Destroy(GameObject.FindGameObjectsWithTag("Point")[x]);
        }
        List<GameObject> gPoints = new List<GameObject>();

        for (int x = 0; x < ListSize(points); x++) {
            var pointObject = Instantiate(point, new Vector3((float)points[x].position[0], (float)points[x].position[1]), transform.rotation) as GameObject;
            pointObject.name = points[x].pointName;
            gPoints.Add(pointObject);
        }
        StartCoroutine(PointChange(gPoints, points));
    }

    private IEnumerator PointChange(List <GameObject> gPoints, List <JsonOpen> points) {
        yield return new WaitForEndOfFrame();

        for (int x = 0; x < gListSize(gPoints); x++) {
            GameObject gPoint = gPoints[x];
            for (int z = 0; z < GameObject.FindGameObjectsWithTag("Point").Length; z++) {
                GameObject find = GameObject.FindGameObjectsWithTag("Point")[z];
                if (points[x].connection == find.name) {
                    gPoint.GetComponent<DrawLine>().target = find;
					gPoint.GetComponent<PointInfo>().connection = find;
				}
                if (points[x].snapPoint == find.name) {
                    gPoint.GetComponent<PointInfo>().snapPoint = find;
                }
            } 
        }
        StartCoroutine(turnOffScripts());
    }

    private IEnumerator turnOffScripts() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++) {
            GameObject found = GameObject.FindGameObjectsWithTag("Point")[x];
            if (found.GetComponent<PointInfo>().snapPoint != null) {
                found.GetComponent<DrawLine>().enabled = false;
                found.GetComponent<PointClick>().enabled = false;
            }
        }
		GetComponent<ConnectionAdder>().ParentAttacher();
	}

    private int ListSize(List <JsonOpen> points) {
        int x = 0;
        while (true){
            try{
                if (points[x] == null)
                { }
                x++;
            }
            catch{
                return x;
            }
        }
    }

    private int gListSize(List<GameObject> points){
        int x = 0;
        while (true){
            try{
                if (points[x] == null)
                { }
                x++;
            }
            catch{
                return x;
            }
        }
    }
}
