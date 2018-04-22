<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Update : MonoBehaviour {

    public float speed;
    public GameObject cam;
    public float border;
    private float dirX;
    private float dirY;
    public float heldTime = 0.0f;
    public UI_Manager CurrentCarbu;

    public AudioSource Fly;
    private float Volume = 1.0f;

    private Rigidbody2D rg2D;

    private void Start()
    {
        Fly = GetComponent<AudioSource>();
        rg2D = GetComponent<Rigidbody2D>();
    }

    void Update () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        rg2D.velocity = transform.forward * speed * Time.deltaTime;
        
            dirX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            dirY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(dirX, dirY, 0, Space.World);

        // décrémentation jauge carburant
        if (dirX != 0 || dirY != 0)
        {
            Volume += 0.05f;
            Fly.volume = Volume;
            CurrentCarbu.UpdateCarbu();
        }
        else {
            Fly.volume -= 0.05f;
        }

        cam.transform.Translate(dirX * (Mathf.Abs(cam.transform.position.x - transform.position.x) / (8.9f - border)), 0, 0, Space.World);
        cam.transform.Translate(0, dirY * (Mathf.Abs(cam.transform.position.y - transform.position.y) / (5f - border)), 0, Space.World);

        
    }

}
=======
=======
>>>>>>> parent of 765f4b6... v0.4f
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Update : MonoBehaviour {

    public float speed;
    public GameObject cam;
    public float border;
    private float dirX;
    private float dirY;
    public float heldTime = 0.0f;
    public UI_Manager CurrentCarbu;

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
        
            dirX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            dirY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(dirX, dirY, 0, Space.World);

        // décrémentation jauge carburant
        if (dirX != 0 || dirY != 0)
        {
            CurrentCarbu.UpdateCarbu();
        }

        cam.transform.Translate(dirX * (Mathf.Abs(cam.transform.position.x - transform.position.x) / (8.9f - border)), 0, 0, Space.World);
        cam.transform.Translate(0, dirY * (Mathf.Abs(cam.transform.position.y - transform.position.y) / (5f - border)), 0, Space.World);

        
    }

}
<<<<<<< HEAD
>>>>>>> 3731406eba917166da5f8a33d85a678395b8651a
=======
>>>>>>> parent of 765f4b6... v0.4f
