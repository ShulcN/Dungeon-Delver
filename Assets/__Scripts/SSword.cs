using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSword : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject projectilePrefab;
    public float prSpd=6;
    public float maxDal=5;
    private GameObject SuperSword;
    private float Reloaded;
    private int facing;
    private Dray dray;
    private Rigidbody rigid;
    private Animator anim;
    private Vector3 p0, p1;
    private Collider drayColld;
    private Vector3[] directions = new Vector3[]
    {
        Vector3.right, Vector3.up, Vector3.left, Vector3.down
    };
    // Start is called before the first frame update
    void Awake()
    {
        
        dray = GetComponent<Dray>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        

        Transform trans = transform.Find("SuperSword");
        SuperSword = trans.gameObject;
        SuperSword.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!dray.hasSuperSword) return;
        if (Input.GetKeyDown(KeyCode.G) && Reloaded < Time.time)
        {
            
            Fire();
        }
        
    }
    void Fire()
    {
        facing = dray.GetFacing();
        anim.CrossFade("Dray_Attack_" + facing, 0);
        anim.speed = 0;
        p1 = transform.position + (directions[facing] * 0.5f);
        SuperSword.transform.position = p1;
        SuperSword.transform.rotation = Quaternion.Euler(0, 0, 90*facing);

        SuperSword.SetActive(true);
        
        GameObject go = Instantiate(projectilePrefab);
        p0 = dray.transform.position+directions[facing]*1.5f;
        go.transform.position = p0;
        Rigidbody rigidB = go.GetComponent<Rigidbody>();
        rigidB.velocity = directions[facing] * prSpd;
        
        Reloaded = Time.time + 2;
        Invoke("TurnOff", 0.1f); 
    }
    void TurnOff()
    {
        SuperSword.SetActive(false);
    }
}
