using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CustomerGetPostitionToExit : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.customer.seat == null) return State.Running;
        
        blackboard.moveToPosition.x = context.customer.exitPos.position.x;
        blackboard.moveToPosition.z = context.customer.exitPos.position.z;
        
        return State.Success;
    }
}
