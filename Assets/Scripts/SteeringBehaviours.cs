using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours
{
    static public Vector3 Seek(SBAgent agent, Transform target, float range = 9999)
    {
        Vector3 desired = Vector3.zero;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;
        desired = difference.normalized * agent.maxSpeed;
        Vector3 steer;
        if (distance < range)
        {
            steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        }
        else
        {
            steer = Vector3.zero;
        }

        return steer;
    }

    static public Vector3 Flee(SBAgent agent, Transform target, float range = 99999)
    {
        Vector3 desired = Vector3.zero;
        Vector3 difference = -(target.position - agent.transform.position);
        float distance = difference.magnitude;
        desired = difference.normalized * agent.maxSpeed;
        Vector3 steer;
        if (distance < range)
        {
            steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        }
        else
        {
            steer = Vector3.zero;
        }

        return steer;
    }

    static public Vector3 Separate(SBAgent agent, List<GameObject> agentToAvoid, float range)
    {
        Vector3 steer = Vector3.zero;
        for (int i = 0; i < agentToAvoid.Count; i++)
        {
            steer += Flee(agent, agentToAvoid[i].transform, range);
        }
        
        return steer;
    }
}
