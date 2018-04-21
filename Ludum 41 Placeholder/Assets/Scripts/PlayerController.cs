using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject cam;
    public float border;

    public UI_Manager CurrentCarbu;
    
    private Vector3 dir;

    void Update () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);

        // décrémentation jauge carburant
        if (dir.x != 0 || dir.y != 0)
        {
            CurrentCarbu.UpdateCarbu();
        }

        cam.transform.Translate(dir.x * (Mathf.Abs(cam.transform.position.x - transform.position.x) / (8.9f - border)), 0, 0, Space.World);
        cam.transform.Translate(0, dir.y * (Mathf.Abs(cam.transform.position.y - transform.position.y) / (5f - border)), 0, Space.World);

        if (Input.GetAxis("Fire1") == 1)
            GetComponent<Weapon>().Shoot();

        if (Input.GetAxis("Fire2") == 1)
            GetComponent<Weapon>().fireRate = .01f;
        else
            GetComponent<Weapon>().fireRate = .2f;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Spawn(dir);
            collision.transform.position = transform.position;
        }
    }
}
