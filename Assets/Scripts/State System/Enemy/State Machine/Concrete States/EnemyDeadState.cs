using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        enemy.ChangeAnimation("EnemyDead");
        ScoreManager.instance.ScorePlus(enemy.scoreValue);
        enemy.cc2d.enabled = false;
        enemy.actionFinished = false;
        enemy.rb2d.velocity = Vector3.zero;
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
            DirectorController.instance.WinScene();
        }
    }

    public override void Physics()
    {
        base.Physics();

    }
}
