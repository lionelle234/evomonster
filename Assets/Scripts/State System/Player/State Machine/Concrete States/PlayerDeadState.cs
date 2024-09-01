using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTrigger(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();


        player.ChangeAnimation("Virus" + player.currentEvo + "Dead");

        player.cc2d.enabled = false;
        player.canReceiveInputLunge = false;
        player.canReceiveInputShield = false;
        player.canReceiveInputShoot = false;
        player.inputReceivedShoot = false;
        player.playerInput.enabled = false;
        player.isShooting = false;
        player.rb2d.velocity = Vector3.zero;
        DirectorController.instance.DeathSound();


    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Frame()
    {
        base.Frame();

        if (player.actionFinished)
        {
            DirectorController.instance.RetryGame();
        }


    }

    public override void Physics()
    {
        base.Physics();

    }
}
