using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WaiterGetStatus : ActionNode
{
    public WaiterStatus SuccessStatus;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        
        return SuccessStatus==context.waiter.waiterStatus? State.Success :State.Failure;
    }
}
