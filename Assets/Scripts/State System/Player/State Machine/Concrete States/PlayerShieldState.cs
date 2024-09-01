using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldState : PlayerState
{
    public PlayerShieldState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTrigger(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        player.canReceiveInputShoot = false;
        player.canReceiveInputLunge = false;
        player.canReceiveInputShield = false;
        player.inputReceivedShield = false;
        player.inputReceivedLunge = false;
        player.isVulnerable = false;
        player.ChangeAnimation("Virus" + player.currentEvo + "Shield");
    }

    public override void Exit()
    {
        base.Exit();

        player.isVulnerable = true;
    }

    public override void Frame()
    {
        base.Frame();
    }

    public override void Physics()
    {
        base.Physics();

        if (player.movInput.y != 0)
        {
            player.movInput.Normalize();

            player.rb2d.AddForce(new Vector3(0, player.movInput.y) * player.moveSpeed, ForceMode2D.Impulse);
            player.rb2d.velocity = Vector3.ClampMagnitude(player.rb2d.velocity, player.moveSpeed);


        }
        else
        {
            player.rb2d.velocity = Vector3.zero;

        }
    }
}
