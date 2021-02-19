using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviourAndWeight
{
    public SteeringBehavior behaviour = null;
    public float weight = 0f;
}

public class blendedSteering
{
    public behaviourAndWeight[] behaviours;
    float maxAcceleration = 1f;
    float maxRotation = 5f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        foreach (behaviourAndWeight b in behaviours)
        {
            SteeringOutput s = b.behaviour.getSteering();
            if (s != null)
            {
                result.linear += s.linear * b.weight;
                result.angular += s.angular * b.weight;
            }

        }

        result.linear = result.linear.normalized * maxAcceleration;
        float angularAcceleration = Mathf.Abs(result.angular);

        if (angularAcceleration > maxRotation)
        {
            result.angular /= angularAcceleration;
            result.angular *= maxRotation;
        }

        return result;
    }



}
