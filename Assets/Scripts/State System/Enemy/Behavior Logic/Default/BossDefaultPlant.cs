using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default-Plant", menuName = "Boss Logic/Default Logic/Plant")]

public class BossDefaultPlant : EnemyDefaultMachine
{
    private GameObject core1, core2;
    private bool core1Destroyed, core2Destroyed, phase1, phase2;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();


        core1 = GameObject.Find("Tentacle1 (Core)");
        core2 = GameObject.Find("Tentacle2 (Core)");
        enemy.isShielded = true;
        enemy.ChangeAnimation("EnemyDefault");
    }

    public override void ExitLogic()
    {
        base.ExitLogic();

        if (!phase1 && core1Destroyed)
        {
            phase1 = true;
        }
        if (!phase2 && core2Destroyed)
        {
            phase2 = true;
        }
    }

    public override void FrameLogic()
    {
        base.FrameLogic();

        if (core1 == null)
        {
            core1Destroyed = true;
        }

        if (core2 == null)
        {
            core2Destroyed = true;
        }

        if (core1Destroyed && !phase1)
        {
            enemy.ChangeState("aggro");
        }

        if (core2Destroyed && !phase2)
        {
            enemy.ChangeState("aggro");
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
