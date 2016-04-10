using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ConnectionAdder : MonoBehaviour {

	public void ParentAttacher() {
		GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

		for (int x = 0; x < points.Length; x++) {
			if (points[x].GetComponent<PointInfo>().snapPoint != null) {
				points[x].GetComponent<PointInfo>().snapPoint.GetComponent<PointInfo>().connections.Add(points[x].GetComponent<PointInfo>().connection);
			}
			else {
				if (points[x].GetComponent<PointInfo>().connection != null) {
					points[x].GetComponent<PointInfo>().connections.Add(points[x].GetComponent<PointInfo>().connection);
				}
			}
		}
		ConnectionAdjuster();
	}

	void ConnectionAdjuster() {
		GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

		for (int x = 0; x < points.Length; x++) {
			for (int z = 0; z < PointConnectionsLength(points[x]); z++) {
				if (points[x].GetComponent<PointInfo>().connections[z].GetComponent<PointInfo>().snapPoint != null) {
					points[x].GetComponent<PointInfo>().connections[z] = points[x].GetComponent<PointInfo>().connections[z].GetComponent<PointInfo>().snapPoint;
				}
			}
		}
		DoubleCheck();
	}

	void DoubleCheck(int check = 1) {
		GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
		for (int x = 0; x < points.Length; x++) {
			List<GameObject> tempList = new List <GameObject> (points[x].GetComponent<PointInfo>().connections);
			IEnumerable <GameObject> temp = tempList;
			points[x].GetComponent<PointInfo>().connections.Clear();
			foreach (GameObject tempObject in temp){
				points[x].GetComponent<PointInfo>().connections.Add(tempObject);
			}
		}
		LinkSend();
	}

	void LinkSend() {
		GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

		for (int x = 0; x < points.Length; x++) {
			for (int z = 0; z < PointConnectionsLength(points[x]); z++) {
				points[x].GetComponent<PointInfo>().connections[z].GetComponent<PointInfo>().connections.Add(points[x]);
			}
		}
		UniqueList();
	}

	void UniqueList() {
		GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
		for (int x = 0; x < points.Length; x++) {
			List<GameObject> uLister = new List<GameObject>();
			for (int z = 0; z < PointConnectionsLength(points[x]); z++) {
				if (Unique(points[x].GetComponent<PointInfo>().connections[z], uLister)) {
					uLister.Add(points[x].GetComponent<PointInfo>().connections[z]);
				}
			}
			points[x].GetComponent<PointInfo>().connections = uLister;
		}
	}

	bool Unique(GameObject point, List<GameObject> uList) {
		for (int x = 0; x < uListSize(uList); x++) {
			if (point == uList[x]) {
				return false;
			}
		}
		return true;
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

	int PointConnectionsLength(GameObject point) {
		int connectionSize = 0;
		while (true) {
			try {
				if (point.GetComponent<PointInfo>().connections[connectionSize] != null) { }
				connectionSize++;
			}
			catch {
				return connectionSize;
			}
		}
	}
}
