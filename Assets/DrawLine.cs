using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour {

    public GameObject target;
    private LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent< LineRenderer >();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 p1 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 100f);
            Vector3 p2 = new Vector3(target.transform.position.x, target.transform.position.y, 100f);
            line.SetPosition(0, p1);
            line.SetPosition(1, p2);
            float distance = Vector2.Distance(transform.position, target.transform.position);
            line.material.mainTextureScale = new Vector2(distance, 1);
            line.sortingOrder = 0;
        }
    }
}
