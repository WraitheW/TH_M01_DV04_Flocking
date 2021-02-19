using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : Kinematic
{
    public bool avoidObstacles = false;
    public GameObject centerOfFlock;
    blendedSteering mySteering;
    prioritySteering myPriority;
    public Kinematic[] kBirds;

    void Start()
    {
        //Separation
        Separation separate = new Separation();
        separate.character = this;

        GameObject[] goBirds = GameObject.FindGameObjectsWithTag("bird");
        kBirds = new Kinematic[goBirds.Length - 1];
        int j = 0;
        for (int i = 0; i < goBirds.Length - 1; i++)
        {
            if (goBirds[i] == this)
            {
                continue;
            }
            kBirds[j++] = goBirds[i].GetComponent<Kinematic>();
        }
        separate.targets = kBirds;

        //Arrive
        Arrive arrive = new Arrive();
        arrive.character = this;
        arrive.target = centerOfFlock;

        //Look Where Going
        LookWhereGoing LWG = new LookWhereGoing();
        LWG.character = this;

        //Blended Steering
        mySteering = new blendedSteering();
        mySteering.behaviours = new behaviourAndWeight[3];
        mySteering.behaviours[0] = new behaviourAndWeight();
        mySteering.behaviours[0].behaviour = separate;
        mySteering.behaviours[0].weight = 1f;
        mySteering.behaviours[1] = new behaviourAndWeight();
        mySteering.behaviours[1].behaviour = arrive;
        mySteering.behaviours[1].weight = 1f;
        mySteering.behaviours[2] = new behaviourAndWeight();
        mySteering.behaviours[2].behaviour = LWG;
        mySteering.behaviours[2].weight = 1f;

        ////Priority Steering
        //ObstacleAvoidance avoider = new ObstacleAvoidance();
        //avoider.character = this;
        //avoider.flee = true;
        //avoider.target = centerOfFlock;

        //blendedSteering avoidance = new blendedSteering();
        //avoidance.behaviours = new behaviourAndWeight[1];
        //avoidance.behaviours[0] = new behaviourAndWeight();
        //avoidance.behaviours[0].behaviour = avoider;
        //avoidance.behaviours[0].weight = 1f;

        //myPriority = new prioritySteering();
        //myPriority.groups = new blendedSteering[2];
        //myPriority.groups[0] = new blendedSteering();
        //myPriority.groups[0] = mySteering;
        //myPriority.groups[1] = new blendedSteering();
        //myPriority.groups[1] = avoidance;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();

        //if (avoidObstacles)
        //{
        //    steeringUpdate = myPriority.getSteering();
        //}
        //else
        //{
        //    steeringUpdate = mySteering.getSteering();
        //}
        steeringUpdate = mySteering.getSteering();
        base.Update();
    }
}
