using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDefaultState : PlayerState
{
    public PlayerDefaultState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTrigger(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();


        player.ChangeAnimation("Virus" + player.currentEvo + "Default");
        if (player.index == 1)
        {

            player.canReceiveInputShoot = true;
        }
        else
        {

            player.canReceiveInputShoot = false;
        }
        player.canReceiveInputLunge = true;
        player.canReceiveInputShield = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Frame()
    {
        base.Frame();

        if (player.inputReceivedShield)
        {
            player.ChangeState("shield");
        }

    }

    public override void Physics()
    {
        base.Physics();

        if (player.movInput.y != 0)
        {
            if (!player.inputReceivedLunge)
            {
                player.movInput.Normalize();

                player.rb2d.AddForce(new Vector3(0, player.movInput.y) * player.moveSpeed, ForceMode2D.Impulse);
                player.rb2d.velocity = Vector3.ClampMagnitude(player.rb2d.velocity, player.moveSpeed);
            }
            else
            {
                player.rb2d.velocity = Vector3.zero;
                player.ChangeState("lunge");
            }


        }
        else
        {
            player.rb2d.velocity = Vector3.zero;

            if (player.inputReceivedLunge)
            {
                player.ChangeState("lunge");
            }
        }
    }
}
