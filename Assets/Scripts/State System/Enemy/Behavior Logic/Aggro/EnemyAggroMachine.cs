using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroMachine : ScriptableObject
{
    protected Enemy enemy;
    protected GameObject gameObject;
    protected Transform transform;





    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        transform = gameObject.transform;
        this.gameObject = gameObject;
        this.enemy = enemy;

    }

    public virtual void EnterLogic() { }

    public virtual void ExitLogic() { }

    public virtual void FrameLogic()
    {

    }

    public virtual void PhysicsLogic() { }

    public virtual void AnimationTriggerLogic(Enemy.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
