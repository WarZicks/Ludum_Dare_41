using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate;
    public GameObject ammo;

    private float rof;
    private Transform[] weapons;

    void Start () {
        rof = fireRate;
        weapons = GetAllChilds(transform);
    }

    private void Update()
    {
        rof -= Time.deltaTime;
    }

    public void Shoot () {
        if (rof <= 0)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                var tra = weapons[i].transform;
                Instantiate(ammo, tra.position, tra.rotation);
                rof = fireRate;
            }
        }
    }

    Transform[] GetAllChilds(Transform t)
    {
        int o = t.childCount;
        List<Transform> tabl = new List<Transform>();
        for (int i = 0; i < o; i++)
        {
            tabl.Add(t.GetChild(i));
        }
        return tabl.ToArray();
    }
}
