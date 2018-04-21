using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour {

    public float lifetime;

	void Update () {
        Destroy(gameObject, lifetime);
	}
}
