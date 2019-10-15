using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : SBAgent
{
    Transform target;
    private int indexTarget;

    void Start()
    {
        maxSpeed = 2f;
        maxSteer = 6f;

        target = Target.targetsAB[0];
    }

    void Update()
    {
        velocity+=SteeringBehaviours.Seek(this,Target.targetsAB[indexTarget],5);
        
        //velocity+=SteeringBehaviours.Separate(this,Instanciador.Players,5);
        
        transform.position += velocity * Time.deltaTime;

        if(Vector3.Distance(transform.position,target.position)<=0.5f)
        {
            NextTarget();
        }
    }

    public void NextTarget()
    {
        if(indexTarget  >= Target.targetsAB.Length - 1)
        {
           EndTarget();
           return;
        }
        indexTarget++;
		target = Target.targetsAB[indexTarget];
    }

    public void EndTarget()
    {
        Destroy(gameObject);
    }
}
