using UnityEngine;

public class Evade : Flee
{
    float predictionTimeMax = 5f;

    protected override Vector3 getTargetPosition()
    {
        Vector3 targetDirection = character.transform.position - target.transform.position;
        float targetDistance = targetDirection.magnitude;
        float speed = character.linearVelocity.magnitude;
        float predictionTime;

        if (speed <= targetDistance / predictionTimeMax)
        {
            predictionTime = predictionTimeMax;
        }
        else
        {
            predictionTime = targetDistance / speed;
        }

        Kinematic movingTarget = target.GetComponent<Kinematic>();
        if (movingTarget == null)
        {
            return base.getTargetPosition();
        }

        return  (movingTarget.linearVelocity * predictionTime) - target.transform.position;
    }
}
