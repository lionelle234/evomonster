using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aggro-UpDown", menuName = "Enemy Logic/Aggro Logic/UpDown")]

public class EnemyAggroUpDown : EnemyAggroMachine
{
    private float timer;
    [SerializeField] private float count1, count2, force;
    private float count;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        timer = 0;
        count = Random.Range(count1, count2);
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
            enemy.shoot.ShootProjectile();
            count = Random.Range(count1, count2);
            timer = 0;
        }


    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        enemy.rb2d.AddForce(new Vector3(0, enemy.speedY) * force, ForceMode2D.Impulse);
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
