using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject cam;
    public float border;

    private Rigidbody2D rg2D;

    private void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
    }

    void Update () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        rg2D.velocity = transform.forward * speed * Time.deltaTime;

        float dirX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float dirY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(dirX, dirY, 0, Space.World);

        cam.transform.Translate(dirX * (Mathf.Abs(cam.transform.position.x - transform.position.x) / (8.9f - border)), 0, 0, Space.World);
        cam.transform.Translate(0, dirY * (Mathf.Abs(cam.transform.position.y - transform.position.y) / (5f - border)), 0, Space.World);

        /*if (Mathf.Abs(cam.transform.position.x - transform.position.x) > 8.9 - 2)
            cam.transform.Translate(dirX, 0, 0, Space.World);
        if (Mathf.Abs(cam.transform.position.y - transform.position.y) > 5 - 2)
            cam.transform.Translate(0, dirY, 0, Space.World);*/

        //transform.forward = new Vector3 (Input.GetAxis("Horizontal"), 0, 0);
    }

}
