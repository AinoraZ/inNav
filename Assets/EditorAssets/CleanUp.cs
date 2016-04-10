using UnityEngine;
using System.Collections;

public class CleanUp : MonoBehaviour {
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(CleanUpStart());
        }
    }

    IEnumerator CleanUpStart() {
        yield return new WaitForEndOfFrame();
        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++) {
            GameObject temp = GameObject.FindGameObjectsWithTag("Point")[x];
            if (temp.GetComponent<PointInfo>().connection == null && temp.GetComponent<PointInfo>().snapPoint != null) {
                Destroy(temp);
            }
        }
    }
}
