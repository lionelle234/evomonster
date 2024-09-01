using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroState : EnemyState
{
    public EnemyAggroState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);

        enemy.EnemyAggroInstance.AnimationTriggerLogic(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        enemy.EnemyAggroInstance.EnterLogic();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.EnemyAggroInstance.ExitLogic();
    }

    public override void Frame()
    {
        base.Frame();

        enemy.EnemyAggroInstance.FrameLogic();
    }

    public override void Physics()
    {
        base.Physics();

        enemy.EnemyAggroInstance.PhysicsLogic();
    }
}
