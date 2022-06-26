using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CustomerChangeStatus : ActionNode
{
    public CustomerStatus newCustomerStatus;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        context.customer.customerStatus = newCustomerStatus;
        switch (newCustomerStatus)
        {
            case CustomerStatus.Nothings:
                break;
            case CustomerStatus.Seated:
                context.customer.seat.ChangeSeatStatus (SeatStatus.CustomerSeated,context.customer) ;
                break;
            case CustomerStatus.Ordered:
                break;
            case CustomerStatus.ReceiveOrdered:
                break;
            case CustomerStatus.Complete:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return State.Success;
    }
}
