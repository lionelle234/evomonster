using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThirdPhaseState : EnemyState
{
    private float timer;
    public EnemyThirdPhaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ChangeAnimation("EnemyThirdPhase");
        enemy.isShielded = false;
        timer = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Frame()
    {
        base.Frame();
        
        if (timer < 2)
        {
            timer += Time.deltaTime;
        }
        else
        {
            enemy.ChangeState("laser");
        }
    }

    public override void Physics()
    {
        base.Physics();
    }
}
