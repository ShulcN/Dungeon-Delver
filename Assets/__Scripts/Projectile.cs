using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 p0, p1;
    void Start()
    {
        p0 = transform.position;
    }
    void Update()
    {
        p1 = transform.position;
        if (Mathf.Abs(Mathf.Max(p0.x, p1.x)-Mathf.Min(p0.x, p1.x)) > 7 || Mathf.Abs(Mathf.Max(p0.y, p1.y) - Mathf.Min(p0.y, p1.y)) > 7)
        {
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name != "DelverTiles_96")
        {
            Destroy(gameObject);
        } 
    }
}
