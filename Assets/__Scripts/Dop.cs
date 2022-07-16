using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dop : MonoBehaviour
{
    private Dray dray;
    private Collider drayColld;
    private Animator anim;
    [Header("Set in inspector: die")]
    public GameObject FonPrefab;
    //[Header("Set dynamically")]
    private Vector3 lastPos;
    void Awake()
    {
        dray = GetComponent<Dray>();
        drayColld = dray.GetComponent<Collider>();
        anim = dray.GetComponent<Animator>();
    }
    public void Die()
    {
        //lastPos = new Vector3(55.5f, 1, 0);
        lastPos = dray.lastPos;
        dray.enabled = false;
        anim.speed = 0;
        dray.invincible = true;
        //drayColld.enabled = false;
        transform.position = lastPos;
        GameObject go = Instantiate(FonPrefab);


    }
    
        
}
