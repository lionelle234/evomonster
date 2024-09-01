using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aggro-Stationary", menuName = "Enemy Logic/Aggro Logic/Stationary")]

public class EnemyAggroStationary : EnemyAggroMachine
{
    private float timer;
    [SerializeField] private float count1, count2;
    private float count;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        timer = 0;
        count = Random.Range(count1, count2);
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameLogic()
    {
        base.FrameLogic();


        if (timer < count)
        {
            timer += Time.deltaTime;
        }
        else
        {
            enemy.shoot.ShootProjectile();
            count = Random.Range(count1, count2);
            timer = 0;
        }



    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();



    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
