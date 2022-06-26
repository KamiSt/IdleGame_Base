using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public WaiterStatus waiterStatus = WaiterStatus.Idle;

    public Seat seat;
    public Machine machine;
    public SOProduct product;
    
   
    
    public void SetUpOrder(Seat seat)
    {
        this.seat = seat;
        waiterStatus = WaiterStatus.GoToOrdering;
        
    }

    public void SetUpProduct(Seat seat,Machine machine)
    {
        this.seat = seat;
        this.machine = machine;
        waiterStatus = WaiterStatus.GoToMachine;
    }
    
    
}
