using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletos : Enemy, IFacingMover
{
    [Header("Set in Inspector")]
    public int speed = 2;
    public float timThinkMin = 1f;
    public float timThinkMax = 4f;

    [Header("Set Dynamically")]
    public int facing = 0;
    public float timNextDecision = 0;

    private InRoom inRm;
    protected override void Awake()
    {
        base.Awake();
        inRm = GetComponent<InRoom>();

    }
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (knockback) return;
        if (Time.time >= timNextDecision)
        {
            DecideDirection();

        }
        rigid.velocity = directions[facing] * speed;
    }
    void DecideDirection()
    {
        facing = Random.Range(0, 4);
        timNextDecision = Time.time + Random.Range(timThinkMin, timThinkMax);
    }
    public int GetFacing()
    {
        return facing;
    }
    public bool moving { get { return true; } }
    public float GetSpeed()
    {
        return speed;
    }
    public float gridMult
    {
        get { return inRm.gridMult; }
    }
    public Vector2 roomPos
    {
        get
        {
            return inRm.roomPos;
        }
        set
        {
            inRm.roomPos = value;
        }
    }
    public Vector2 roomNum
    {
        get
        {
            return inRm.roomNum;
        }
        set
        {
            inRm.roomNum = value;
        }
    }
    public Vector2 GetRoomPosOnGrid (float mult = -1)
    {
        return inRm.GetRoomPosOnGrid(mult);
    }
}
