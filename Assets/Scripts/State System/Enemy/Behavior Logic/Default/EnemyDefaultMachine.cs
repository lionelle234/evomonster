using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultMachine : ScriptableObject
{
    protected Enemy enemy;
    protected GameObject gameObject;
    protected Transform transform;





    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {

        this.enemy = enemy;
        this.gameObject = gameObject;
        transform = gameObject.transform;

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
