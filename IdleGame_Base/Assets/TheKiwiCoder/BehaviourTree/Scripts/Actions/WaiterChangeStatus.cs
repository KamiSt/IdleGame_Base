using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WaiterChangeStatus : ActionNode
{
    public WaiterStatus newWaiterStatus;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (context.waiter.waiterStatus == WaiterStatus.Ordering 
            && newWaiterStatus == WaiterStatus.Idle)
        {
            context.waiter.seat.Ordered();
            context.waiter.seat = null;
        }
        else if (context.waiter.waiterStatus==WaiterStatus.GoToOrdering 
                 && newWaiterStatus==WaiterStatus.Ordering)
        {
            context.waiter.seat.Ordering();
        }
        else if (context.waiter.waiterStatus == WaiterStatus.MakeProduct &&newWaiterStatus == WaiterStatus.HandOver)
        {
            context.waiter.machine.status = Status.Idle;
            context.waiter.product = context.waiter.machine.machineData.product;
            context.waiter.machine = null;
        }
        else if (context.waiter.waiterStatus == WaiterStatus.HandOver &&newWaiterStatus == WaiterStatus.Idle)
        {
            context.waiter.seat.ReceiveOrder(context.waiter.product);
            context.waiter.product = null;
           
        }

        context.waiter.waiterStatus = newWaiterStatus;
        return State.Success;
    }
}
