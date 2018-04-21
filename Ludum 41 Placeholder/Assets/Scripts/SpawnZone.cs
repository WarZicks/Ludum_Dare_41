using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour {

    public GameObject enemy;

	void Start () {
        for (int i = 0; i <= 10; i++)
        {
            var ene = Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, Random.Range(-180f, 180f)));
            ene.transform.parent = gameObject.transform;
        }
    }

    private void Update()
    {
        if (transform.childCount <= 0)
            Destroy(gameObject);
    }
}
