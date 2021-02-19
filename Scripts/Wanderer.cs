using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Kinematic
{
    Wander myMoveType;
    LookWhereGoing myRotateType;

    public float xRange1;
    public float xRange2;

    public float zRange1;
    public float zRange2;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Wander();
        myMoveType.character = this;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;

        myMoveType.xRange1 = xRange1;
        myMoveType.xRange2 = xRange2;
        myMoveType.zRange1 = zRange1;
        myMoveType.zRange2 = zRange2;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
