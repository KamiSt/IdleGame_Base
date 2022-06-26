using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class CustomerGetPositionForSeat : ActionNode
{
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (context.customer.seat == null) return State.Running;
       
        blackboard.moveToPosition.x = context.customer.seat.customerPos.position.x;
        blackboard.moveToPosition.z = context.customer.seat.customerPos.position.z;
        return State.Success;
        
    }
}
