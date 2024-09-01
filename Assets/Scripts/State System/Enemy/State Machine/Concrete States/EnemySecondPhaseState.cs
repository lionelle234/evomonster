using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySecondPhaseState : EnemyState
{
    public EnemySecondPhaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ChangeAnimation("EnemySecondPhase");
        enemy.isShielded = true;
        enemy.rb2d.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Frame()
    {
        base.Frame();
    }

    public override void Physics()
    {
        base.Physics();


    }
}
