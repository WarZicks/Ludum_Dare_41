using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed, health;
    public GameObject marker;
    public bool inView, hasMarker;
    public string state;

    private float turnTimer, angle;
    
    void Start () {
        inView = true;
        hasMarker = false;
        state = "in";
        turnTimer = Random.Range(1f, 3f);
    }
	
	void Update () {
        if (state == "in")
        {
            turnTimer -= Time.deltaTime;
            if (turnTimer <= 0)
            {
                turnTimer = Random.Range(.2f, .8f);
                angle = Random.Range(-6f, 6f);
            }
            transform.Rotate(0, 0, angle);
        }
        if (state == "out")
        {
            angle = Mathf.Atan2(transform.parent.transform.position.y - transform.position.y, transform.parent.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            if (Vector3.Distance(transform.position, transform.parent.transform.position) < 3f)
            {
                state = "in";
                angle = Random.Range(-6f, 6f);
            }
        }
        if (state == "triggered")
        {
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            playerPos.z = 0;
            angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            if (inView)
            {
                GetComponent<Weapon>().Shoot();
            }
        }

        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);

        var camPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        if (Mathf.Abs(transform.position.x - camPos.x) > 8.9f || Mathf.Abs(transform.position.y - camPos.y) > 5)
            inView = false;
        else
            inView = true;

        if (!inView && !hasMarker)
        {
            hasMarker = true;
            Spawn();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Spawn()
    {
        var target = Instantiate(marker, transform.position, transform.rotation);
        target.GetComponent<Marker>().parent = gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Zone")
        {
            state = "out";
        }
    }
}
