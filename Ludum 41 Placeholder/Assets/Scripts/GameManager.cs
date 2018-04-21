using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timerInit, timer;
    public GameObject enemy, zoneSpawn;

	void Start () {
		
	}
	
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timerInit;
            Instantiate(enemy, Vector3.zero, Quaternion.identity);
        }
	}

    public void Spawn(Vector3 dir)
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().transform.position;
        Instantiate(zoneSpawn, player + dir * 200, Quaternion.identity);
    }
}
