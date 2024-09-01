using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRetreatState : PlayerState
{
    public PlayerRetreatState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTrigger(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();

        player.ChangeAnimation("Virus" + player.currentEvo + "Retreat");

    }

    public override void Exit()
    {
        base.Exit();

        if (player.shootLocked == -1)
        {
            player.isShooting = true;
            player.inputReceivedShoot = true;
        }
    }

    public override void Frame()
    {
        base.Frame();

    }

    public override void Physics()
    {
        base.Physics();

        if (player.transform.position.x != player.startPosX)
        {
            player.rb2d.AddForce(new Vector3(-1, 0) * player.lungeSpeed, ForceMode2D.Impulse);
            player.rb2d.velocity = Vector3.ClampMagnitude(player.rb2d.velocity, player.lungeSpeed);
            
        }
        else
        {
            player.rb2d.velocity = Vector3.zero;
            player.limitReach = false;
            player.ChangeState("default");
        }
    }
}
