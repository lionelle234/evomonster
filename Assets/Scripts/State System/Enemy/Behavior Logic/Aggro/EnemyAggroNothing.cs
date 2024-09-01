using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aggro-Nothing", menuName = "Enemy Logic/Aggro Logic/Nothing")]

public class EnemyAggroNothing : EnemyAggroMachine
{

    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameLogic()
    {
        base.FrameLogic();




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
