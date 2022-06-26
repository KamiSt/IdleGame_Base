using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CustomerGetStatus : ActionNode
{
    public CustomerStatus SuccessStatus;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        return SuccessStatus == context.customer.customerStatus ? State.Success : State.Failure;
    }
}
