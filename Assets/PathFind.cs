using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFind : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PathFindStart(GameObject start, GameObject end) {
		path.Add(start);
		Calculate(start, end);
	}
	List<GameObject> path;

	void Calculate(GameObject start, GameObject end) {
		for (int x = 0; x < uListSize(start.GetComponent<PointInfo>().connections); x++) {
			if (start.GetComponent<PointInfo>().connections[x] != end) {
				path.Add(start.GetComponent<PointInfo>().connections[x]);
				Calculate(start.GetComponent<PointInfo>().connections[x], end);
				path.Remove(start.GetComponent<PointInfo>().connections[x]);
			}
			else {
				path.Add(start.GetComponent<PointInfo>().connections[x]);
			}
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

