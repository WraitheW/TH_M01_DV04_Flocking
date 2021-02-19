using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    public float avoidDistance = 4f;

    public float lookAhead = 5f;

    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookAhead))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.magenta, 0.5f);
            return hit.point + (hit.normal * avoidDistance);
        }
        else
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * lookAhead, Color.cyan, 0.5f);
            return base.getTargetPosition();
        }
    }
}
