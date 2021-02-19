using UnityEngine;

public class Pursue : Seek
{
    float predictionTimeMax = 5f;

    protected override Vector3 getTargetPosition()
    {
        Vector3 targetDirection = target.transform.position - character.transform.position;
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

        return target.transform.position + movingTarget.linearVelocity * predictionTime;
    }
}
