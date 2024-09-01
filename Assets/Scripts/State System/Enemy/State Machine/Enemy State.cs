using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{

    protected EnemyStateMachine enemyStateMachine;
    protected Enemy enemy;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {

        this.enemyStateMachine = enemyStateMachine;
        this.enemy = enemy;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Frame()
    {

    }

    public virtual void Physics()
    {

    }

    public virtual void AnimationTrigger(Enemy.AnimationTriggerType triggerType)
    {

    }
}
