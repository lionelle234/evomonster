using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aggro-Plant", menuName = "Boss Logic/Aggro Logic/Plant")]

public class BossAggroPlant : EnemyAggroMachine
{
    private GameObject shoot;
    private float timer, count;
    [SerializeField] private float count1, count2;
    private bool phase1, phase2;
    public override void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerLogic(triggerType);
    }

    public override void EnterLogic()
    {
        base.EnterLogic();

        shoot = enemy.transform.GetChild(0).gameObject;
        shoot.SetActive(true);
        timer = 0;
        count = Random.Range(count1, count2);
        enemy.isShielded = false;
        enemy.ChangeAnimation("EnemyAggro");
    }

    public override void ExitLogic()
    {
        base.ExitLogic();

        shoot.SetActive(false);
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
            shoot.GetComponent<SpawnerShootEnemyController>().ShootProjectile();
            count = Random.Range(count1, count2);
            timer = 0;
        }

        if (enemy.currentHealth <= 50 && !phase1)
        {
            phase1 = true;
            enemy.ChangeState("default");
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
