using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultState : EnemyState
{
    public EnemyDefaultState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);

        enemy.EnemyDefaultInstance.AnimationTriggerLogic(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        enemy.EnemyDefaultInstance.EnterLogic();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.EnemyDefaultInstance.ExitLogic();
    }

    public override void Frame()
    {
        base.Frame();

        enemy.EnemyDefaultInstance.FrameLogic();


    }

    public override void Physics()
    {
        base.Physics();

        enemy.EnemyDefaultInstance.PhysicsLogic();
    }
}
