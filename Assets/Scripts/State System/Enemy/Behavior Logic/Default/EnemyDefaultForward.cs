using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default-Forward", menuName = "Enemy Logic/Default Logic/Forward")]

public class EnemyDefaultForward : EnemyDefaultMachine
{
    [SerializeField] private float moveSpeed;
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

        enemy.rb2d.AddForce(new Vector3(-1, 0) * moveSpeed, ForceMode2D.Impulse);
        enemy.rb2d.velocity = Vector3.ClampMagnitude(enemy.rb2d.velocity, moveSpeed);
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
