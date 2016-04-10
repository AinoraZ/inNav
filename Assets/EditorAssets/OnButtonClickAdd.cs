using UnityEngine;
using System.Collections;

public class OnButtonClickAdd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    GameObject active = null;
    bool timerStart = false;
    public float fixTimer = 0.08f;
    float timer = 0f;

    // Update is called once per frame
    void Update () {
        ActiveTimer();
	}

    public GameObject point;

    public void OnButtonAdd() {
        if (active != null) {
            Destroy(active);
        }
        StartCoroutine(Spawn());
    }

    public void OnButtonRemove() {
        if (active != null){
            Destroy(active);
        }
        else
            StartCoroutine(Remove());
    }

    private IEnumerator Remove(){
        yield return new WaitForEndOfFrame();
        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++){
            GameObject.FindGameObjectsWithTag("Point")[x].SendMessage("PointRemove", SendMessageOptions.DontRequireReceiver);
        }
    }

    private IEnumerator Spawn() {
        yield return new WaitForEndOfFrame();
        var spawn = Instantiate(point, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation) as GameObject;

        bool pointWithNameFound = false;

        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++) {
            for (int z = 0; z < GameObject.FindGameObjectsWithTag("Point").Length; z++){
                if (GameObject.FindGameObjectsWithTag("Point")[z].name == ("Point" + (x + 1))) {
                    pointWithNameFound = true;
                }
            }
            if (!pointWithNameFound) {
                spawn.name = "Point" + (x + 1);
            }
            pointWithNameFound = false;
        }
    }

    GameObject ActiveCheck(){
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        for (int x = 0; x < points.Length; x++){
            if (!points[x].GetComponent<PointCreated>().isLocked){
                return points[x];
            }
        }
        return null;
    }

    void ActiveTimer(){
        if (Input.GetMouseButtonDown(0)){
            if (active != null && ActiveCheck() == null && !timerStart){
                timerStart = true;
            }
            if (timerStart){
                timer += Time.deltaTime;
                if (timer > fixTimer)
                {
                    timerStart = false;
                    timer = 0f;
                    if (active != null && ActiveCheck() == null)
                    {
                        active = null;
                    }
                }
            }
            if (ActiveCheck() != null){
                active = ActiveCheck();
            }
        }
    }
}
