using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLungeState : PlayerState
{

    public PlayerLungeState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTrigger(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        player.ChangeAnimation("Virus" + player.currentEvo + "Lunge");

        player.canReceiveInputLunge = false;
        player.canReceiveInputShoot = false;
        player.canReceiveInputShield = false;
        player.inputReceivedLunge = false;
        player.inputReceivedShoot = false;
        player.isLunging = true;



    }

    public override void Exit()
    {
        base.Exit();

        player.isLunging = false;
    }

    public override void Frame()
    {
        base.Frame();

    }

    public override void Physics()
    {
        base.Physics();


        if (!player.limitReach)
        {
            player.rb2d.AddForce(new Vector3(1, 0) * player.lungeSpeed, ForceMode2D.Impulse);
            player.rb2d.velocity = Vector3.ClampMagnitude(player.rb2d.velocity, player.lungeSpeed);
        }
        else
        {
            player.rb2d.velocity = Vector3.zero;
            player.ChangeState("retreat");
        }

    }
}
