using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    public float speed;
    public string target;

	void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);

        var camPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        if (Mathf.Abs(transform.position.x - camPos.x) > 8.9f || Mathf.Abs(transform.position.y - camPos.y) > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == target)
        {
            if (target == "Player")
            {
                collision.GetComponent<PlayerController>();
                Destroy(gameObject);
            }
            if (target == "Enemy")
            {
                collision.GetComponent<EnemyBehavior>().health--;
                Destroy(gameObject);
            }
        }
    }
}
