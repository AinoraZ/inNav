using UnityEngine;
using System.Collections;

public class SaveClick : MonoBehaviour {

    GameObject active = null;
    bool timerStart = false;
    public float fixTimer = 0.08f;
    float timer = 0f;

    // Update is called once per frame
    void Update(){
        ActiveTimer();
        if (BrowserOpen && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            BrowserOpen = false;
            StartCoroutine(ClickedWait(stringToEdit));
            stringToEdit = "Name your file";
        }
        else if (BrowserOpen && Input.GetKeyDown(KeyCode.Escape)) {
            BrowserOpen = false;
            stringToEdit = "Name your file";
        }
    }

    void DataSendCheck() {

    }

    FileBrowser file;
    bool BrowserOpen = false;

    void Awake() {
        file = new FileBrowser(Application.dataPath + "/Saves");
    }

    public void Clicked()
    {
        if (active != null)
        {
            Destroy(active);
        }
        BrowserOpen = true;
    }

    protected string stringToEdit = "Name your file";
    protected Rect rect = new Rect(20, 40, 200, 40);

    void OnGUI()
    {
        if (BrowserOpen)
        {
            GUI.SetNextControlName("TextField1");
            GUI.skin.textField.fontSize = 30;
            GUI.skin.textField.alignment = TextAnchor.MiddleCenter;
            rect.size = new Vector2(400, 50);
            rect.center = new Vector2(Screen.width / 2, Screen.height / 2);
            stringToEdit = GUI.TextField(rect, stringToEdit, 25);
            if (Event.current.keyCode == KeyCode.Return)
            {
                BrowserOpen = false;
                StartCoroutine(ClickedWait(stringToEdit));
                stringToEdit = "Name your file";
            }
            if (Event.current.keyCode == KeyCode.Escape) {
                BrowserOpen = false;
                stringToEdit = "Name your file";
            }
            if (Input.GetMouseButtonDown(0) &&
             GUI.GetNameOfFocusedControl().Equals("TextField1") && stringToEdit == "Name your file")
            {
                stringToEdit = "";
            }
            else if (!GUI.GetNameOfFocusedControl().Equals("TextField1") && stringToEdit == ""){
                    stringToEdit = "Name your file";
            }
        }
    }

    

    IEnumerator ClickedWait(string jsonName)
    {
        yield return new WaitForEndOfFrame();
        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++)
        {
            GameObject.FindGameObjectsWithTag("Point")[x].SendMessage("SaveStart", jsonName);
        }
    }

    GameObject ActiveCheck()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        for (int x = 0; x < points.Length; x++)
        {
            if (!points[x].GetComponent<PointCreated>().isLocked)
            {
                return points[x];
            }
        }
        return null;
    }

    void ActiveTimer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (active != null && ActiveCheck() == null && !timerStart)
            {
                timerStart = true;
            }
            if (timerStart)
            {
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
            if (ActiveCheck() != null)
            {
                active = ActiveCheck();
            }
        }
    }
}
