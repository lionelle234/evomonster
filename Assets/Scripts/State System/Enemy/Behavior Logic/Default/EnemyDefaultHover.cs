using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Default-Hover", menuName = "Enemy Logic/Default Logic/Hover")]
public class EnemyDefaultHover : EnemyDefaultMachine
{
    [SerializeField] private int count1, count2;
    private int random;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        enemy.ChangeAnimation("EnemyDefault");
        random = Random.Range(count1, count2);
        enemy.flashed = false;
        enemy.rb2d.velocity = Vector2.zero;

    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameLogic()
    {
        base.FrameLogic();

        if (enemy.flashed)
        {
            if (random == 1)
            {
                enemy.ChangeState("aggro");
            }
            else
            {

                random = Random.Range(count1, count2);
                enemy.flashed = false;
            }
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
