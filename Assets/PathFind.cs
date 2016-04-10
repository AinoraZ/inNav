using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFind : MonoBehaviour {

    //--Debug---//

    public GameObject startObj;
    public GameObject endObj;

    void Update() {
		if (startObj != null && endObj != null) {
			PathFindStart(startObj, endObj);
			startObj = null;
		}
    }
    //--Debug--//

	public void PathFindStart(GameObject start, GameObject end) {
		path.Add(start);
		StartCoroutine(Calculate(start, end));
	}

	List<GameObject> path = new List<GameObject>();
    List<GameObject> minPath;
    float minimumPath = 9999999999f;

	IEnumerator Calculate(GameObject start, GameObject end) {
		if (minPath == null)
		{
			yield return new WaitForEndOfFrame();
			for (int x = 0; x < uListSize(start.GetComponent<PointInfo>().connections); x++)
			{
				float dist = 0f;
				if (start.GetComponent<PointInfo>().connections[x] != end)
				{
					dist += Vector2.Distance(start.transform.position, start.GetComponent<PointInfo>().connections[x].transform.position);
					if (dist < minimumPath)
					{
						path.Add(start.GetComponent<PointInfo>().connections[x]);
						StartCoroutine(Calculate(start.GetComponent<PointInfo>().connections[x], end));
						path.Remove(start.GetComponent<PointInfo>().connections[x]);
					}
					dist -= Vector2.Distance(start.transform.position, start.GetComponent<PointInfo>().connections[x].transform.position);
				}
				else {
					dist += Vector2.Distance(start.transform.position, start.GetComponent<PointInfo>().connections[x].transform.position);
					if (dist < minimumPath)
					{
						minimumPath = dist;
						path.Add(start.GetComponent<PointInfo>().connections[x]);
						minPath = new List<GameObject>(path);
						path.Remove(start.GetComponent<PointInfo>().connections[x]);
					}
					dist -= Vector2.Distance(start.transform.position, start.GetComponent<PointInfo>().connections[x].transform.position);
				}
			}
			Debug.Log(minPath);
		}
	}

	private int uListSize(List<GameObject> points) {
		int x = 0;
		while (true) {
			try {
				if (points[x] == null) { }
				x++;
			}
			catch {
				return x;
			}
		}
	}
}

