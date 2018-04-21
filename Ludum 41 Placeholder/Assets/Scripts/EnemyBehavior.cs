using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    public GameObject marker;
    public bool outside, hasMarker;

    private Rigidbody2D rg2D;
    
    void Start () {
        rg2D = GetComponent<Rigidbody2D>();
        outside = false;
        hasMarker = false;
    }
	
	void Update () {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos.z = 0;

        float angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        rg2D.velocity = transform.forward * speed * Time.deltaTime;
        
        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);

        if (!outside)
        {
            GetComponent<Weapon>().Shoot();
        }
        if (outside && !hasMarker)
        {
            hasMarker = true;
            Spawn();
        }
    }

    private void OnBecameInvisible()
    {
        outside = true;
    }

    private void OnBecameVisible()
    {
        outside = false;
    }

    void Spawn()
    {
        var target = Instantiate(marker, transform.position, transform.rotation);
        target.GetComponent<Marker>().parent = gameObject;
    }
}
