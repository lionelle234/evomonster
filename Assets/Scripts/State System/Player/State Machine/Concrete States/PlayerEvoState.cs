using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvoState : PlayerState
{
    private float timer;
    public PlayerEvoState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTrigger(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        timer = 0;
        player.foodAmount = 0;
        player.currentHealth = player.maxHealth;
        HUD.instance.HeartHeal();
        HUD.instance.EvoReset();
        player.currentEvo += 1;
        player.inputReceivedShoot = false;
        player.isVulnerable = false;
        player.isShooting = false;
        player.playerInput.enabled = false;
        player.cc2d.radius = 0.17f;
        player.ChangeAnimation("Virus" + (player.currentEvo - 1) + "Evo" + player.currentEvo);
    }

    public override void Exit()
    {
        base.Exit();


        player.playerInput.enabled = true;
        player.isVulnerable = true;
    }

    public override void Frame()
    {
        base.Frame();

        if (timer < 1f)
        {
            player.rb2d.velocity = Vector3.zero;
            timer += Time.deltaTime;
        }
        else
        {
            player.ChangeAnimation("Virus" + player.currentEvo + "Default");
            player.ChangeState("retreat");
        }
    }

    public override void Physics()
    {
        base.Physics();
    }
}
