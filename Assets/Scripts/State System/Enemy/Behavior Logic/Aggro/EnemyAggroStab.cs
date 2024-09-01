using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Aggro-Stab", menuName = "Enemy Logic/Aggro Logic/Stab")]

public class EnemyAggroStab : EnemyAggroMachine
{
    private float timer, timer2, timer3;
    [SerializeField] private float force, count, count2, count3, direction;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        enemy.ChangeAnimation("EnemyGlow");
        enemy.isShielded = true;
        timer = 0;
        timer2 = 0;
        timer3 = 0;
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameLogic()
    {
        base.FrameLogic();

        if (timer < count)
        {
            timer += Time.deltaTime;
        }
        else
        {
            
            if (timer2 < count2)
            {
                direction = -1;
                timer2 += Time.deltaTime;
            }
            else
            {
                if (timer3 < count3)
                {
                    direction = 1;
                    timer3 += Time.deltaTime;
                }
                else
                {
                    direction = 0;
                    enemy.isShielded = false;
                    enemy.ChangeState("default");
                }
            }
        }


    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        enemy.rb2d.AddForce(new Vector3(direction, 0) * force, ForceMode2D.Impulse);
        enemy.rb2d.velocity = Vector3.ClampMagnitude(enemy.rb2d.velocity, force);


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
