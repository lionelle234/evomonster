using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserState : EnemyState
{
    public EnemyLaserState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ChangeAnimation("EnemyLaser");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Frame()
    {
        base.Frame();

        if (enemy.actionFinished)
        {
            enemy.ChangeState("thirdphase");
        }
    }

    public override void Physics()
    {
        base.Physics();
    }
}
