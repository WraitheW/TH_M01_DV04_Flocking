using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehavior
{
    public Kinematic character;

    public float xRange1;
    public float xRange2;

    public float zRange1;
    public float zRange2;

    float maxAcceleration = 5f;

    protected virtual Vector3 getTargetPosition()
    {
        return new Vector3(Random.Range(xRange1, xRange2), (float)0.5d, Random.Range(zRange1, zRange2));
    }

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPosition = getTargetPosition();

        result.linear = targetPosition - character.transform.position;

        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;

        return result;
    }
}
