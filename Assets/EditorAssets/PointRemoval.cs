using UnityEngine;
using System.Collections;

public class PointRemoval : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        sizeAdjustment = GetComponent<PointClick>().sizeAdjustment;
    }

    bool removing = false;
    float sizeAdjustment;

    void PointRemove()
    {
        removing = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (DistanceCalculation() <= sizeAdjustment && GetComponent<PointCreated>().isLocked)
            {
                Remove();
            }
            removing = false;
        }
    }

    void Remove()
    {
        if (removing)
        {
            for (int x = 0; x < GameObject.FindGameObjectsWithTag("Point").Length; x++) {
                if (GameObject.FindGameObjectsWithTag("Point")[x].GetComponent<DrawLine>().target == gameObject) {
                    GameObject temp = GameObject.FindGameObjectsWithTag("Point")[x];
                    temp.GetComponent<DrawLine>().target = null;
                    temp.GetComponent<LineRenderer>().SetPosition(1, new Vector3(temp.transform.position.x, temp.transform.position.y, 100f));
                }
            }
            Destroy(gameObject);
        }
    }


    float DistanceCalculation()
    {
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mPos = new Vector2(mouseWorldSpace.x, mouseWorldSpace.y);

        return Vector2.Distance(mPos, new Vector2(transform.position.x, transform.position.y));
    }

}
