using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : SBAgent
{
    GameObject prefabA;
    GameObject prefabB;

    bool instanciar=false;

    public static List<GameObject> Players= new List<GameObject>();

    private float timeA;
    private float timeB;

    void Start()
    {
        timeA=6f;
        timeB=2f;
    }

    void Update()
    {   
        timeA-=Time.deltaTime;
        timeB-=Time.deltaTime;
        
        if(timeA<=0)
        {
            instanciadorPlayerA();
            timeA=6f;
        }

        if(timeB<=0)
        {
            instanciadorPlayerB();
            timeB=2F;
        }
    }

    public void instanciadorPlayerA()
    {
        prefabA = (GameObject)Instantiate(Resources.Load("npcA"));
        Players.Add(prefabA);
        prefabA.transform.position=this.transform.position;
    }

    public void instanciadorPlayerB()
    {
        prefabB = (GameObject)Instantiate(Resources.Load("npcB"));
        Players.Add(prefabB);
        prefabB.transform.position=this.transform.position;
    }
}
