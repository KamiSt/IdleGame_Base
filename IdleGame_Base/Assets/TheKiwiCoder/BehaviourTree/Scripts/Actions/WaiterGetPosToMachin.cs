using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WaiterGetPosToMachin : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.moveToPosition.x = context.waiter.machine.transform.position.x;
        blackboard.moveToPosition.z = context.waiter.machine.transform.position.z;
        return State.Success;
    }
}
