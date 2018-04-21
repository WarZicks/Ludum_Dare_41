using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    public GameObject parent;

    float height = 4, width = 7.9f;
    Vector3 parPos, camPos;

    void Update () {
        camPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        parPos = parent.transform.position - camPos;
        transform.position = camPos + new Vector3(Mathf.Clamp(parPos.x, -width, width), Mathf.Clamp(parPos.y, -height, height), 10);

        /*if (Mathf.Abs(parPos.x) < 8.9f || Mathf.Abs(parPos.y) < 5)
            Destroy(gameObject);*/
    }
}
