using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Aggro-UpDownBoss", menuName = "Enemy Logic/Aggro Logic/UpDownBoss")]

public class EnemyAggroUpDownBoss : EnemyAggroMachine
{
    private float timer;
    [SerializeField] private float count1, count2, force;
    private float count;
    private Vector2 pos;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        timer = 0;
        pos = enemy.transform.position;
        count = Random.Range(count1, count2);
    }

    public override void ExitLogic()
    {
        base.ExitLogic();
    }

    public override void FrameLogic()
    {
        base.FrameLogic();

        if (enemy.currentHealth >= 40)
        {
            if (timer < count)
            {
                timer += Time.deltaTime;
            }
            else
            {
                enemy.shoot.ShootProjectile();
                count = Random.Range(count1, count2);
                timer = 0;
            }
        }
        else
        {
            timer = 0;
            enemy.transform.position = pos;
            enemy.ChangeState("secondphase");
        }



    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        if (enemy.currentHealth >= 40)
        {

            enemy.rb2d.AddForce(new Vector3(0, enemy.speedY) * force, ForceMode2D.Impulse);
        }
        else
        {
            enemy.rb2d.velocity = Vector2.zero;
        }
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
