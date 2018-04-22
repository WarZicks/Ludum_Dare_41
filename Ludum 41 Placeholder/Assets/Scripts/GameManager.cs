using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timerInit, timer;
    public GameObject enemy;

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
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(enemy, player + dir * 200 + new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f), 0), Quaternion.identity);
        }
    }
}
