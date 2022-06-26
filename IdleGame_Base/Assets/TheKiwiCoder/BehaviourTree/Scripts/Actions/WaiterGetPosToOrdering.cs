using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WaiterGetPosToOrdering : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.waiter.seat == null) return State.Running;
            blackboard.moveToPosition.x = context.waiter.seat.waiterPos.position.x;
            blackboard.moveToPosition.z = context.waiter.seat.waiterPos.position.z;
        return State.Success;
    }
}
