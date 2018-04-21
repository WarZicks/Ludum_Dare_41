using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior1 : MonoBehaviour {

    public float speed, health;
    public GameObject marker;
    public bool outside, hasMarker;

    //déclaration variable d'un objet UI_Manager
    public UI_Manager LifeUp; 
    
    void Start () {
        outside = false;
        hasMarker = false;
    }
	
	void Update () {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos.z = 0;

        float angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        
        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);

        var camPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        if (Mathf.Abs(transform.position.x - camPos.x) > 8.9f || Mathf.Abs(transform.position.y - camPos.y) > 5)
            outside = true;
        else
            outside = false;

        if (!outside)
        {
            GetComponent<Weapon>().Shoot();
        }
        if (outside && !hasMarker)
        {
            hasMarker = true;
            Spawn();
        }

        if (health <= 0)
        {
            LifeUp.CurrentLife += 15;
            Destroy(gameObject);
        }
    }

    void Spawn()
    {
        var target = Instantiate(marker, transform.position, transform.rotation);
        target.GetComponent<Marker>().parent = gameObject;
    }
}
