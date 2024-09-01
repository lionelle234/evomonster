using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default-Stop", menuName = "Enemy Logic/Default Logic/Stop")]

public class EnemyDefaultStop : EnemyDefaultMachine
{
    [SerializeField] private float moveSpeed, count;
    private float timer;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        timer = 0;
        enemy.isShielded = true;

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

        if (timer < count)
        {
            timer += Time.deltaTime;
            enemy.rb2d.AddForce(new Vector3(-1, 0), ForceMode2D.Impulse);
            enemy.rb2d.velocity = Vector3.ClampMagnitude(enemy.rb2d.velocity, moveSpeed);
        }
        else
        {
            enemy.isShielded = false;
            enemy.rb2d.velocity = Vector3.zero;
            enemy.ChangeState("aggro");
        }


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
