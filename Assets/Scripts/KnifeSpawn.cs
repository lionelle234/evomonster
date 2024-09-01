using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawn : MonoBehaviour
{
    [SerializeField] private Enemy[] enemy;
    private Golem golem;
    private bool active, active2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        golem = FindAnyObjectByType<Golem>();

        if (!active)
        {
            if (golem != null)
            {
                if (golem.StateMachine.CurrentState == golem.SecondPhase)
                {
                    enemy[0].transform.gameObject.SetActive(true);
                    enemy[1].transform.gameObject.SetActive(true);
                    active = true;
                }
            }
        }
        else
        {   
            if (!active2)
            {
                if (enemy[0] == null && enemy[1] == null)
                {
                    golem.ChangeState("thirdphase");
                    active2 = true;
                }
            }

        }

    }
}
