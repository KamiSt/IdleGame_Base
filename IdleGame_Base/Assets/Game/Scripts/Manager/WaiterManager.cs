using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class WaiterManager : MonoBehaviour
{
    [SerializeField] private List<Waiter> waiters;
    [SerializeField] private List<Machine> machines;

    private List<Seat> _seatsNeedOrder = new List<Seat>();
    private List<SeatWithOrder> _seatWithOrders = new List<SeatWithOrder>();


    private void OnEnable()
    {
        EventManager.OnRequestOrdering += ReciveRequestOrdering;
        EventManager.OnRequestMakingProduct +=ReciveRequestMakingProduct;
    }

 
    private void OnDisable()
    {
        EventManager.OnRequestOrdering -= ReciveRequestOrdering;
        EventManager.OnRequestMakingProduct -=ReciveRequestMakingProduct;
    }

    private void ReciveRequestOrdering(Seat seat)
    {
        _seatsNeedOrder.Add(seat);
    }
    private void ReciveRequestMakingProduct(Seat seat)
    {
        for (int i = 0; i < seat.orders.Count; i++)
        {
            _seatWithOrders.Add(new SeatWithOrder(seat,seat.orders[i]));
        }
    }


    private void Update()
    {
        if (_seatsNeedOrder.Count > 0)
        {
            foreach (var waiter in waiters)
            {
                if (waiter.waiterStatus == WaiterStatus.Idle)
                {
                   
                    waiter.SetUpOrder(_seatsNeedOrder[0]);
                    _seatsNeedOrder.RemoveAt(0);
                    break;
                }
            }
        }
        else if (_seatWithOrders.Count > 0)
        {
            foreach (var waiter in waiters.Where(waiter => waiter.waiterStatus == WaiterStatus.Idle))
            {
                for (var i = 0; i < _seatWithOrders.Count; i++)
                {
                    var freeMachine = machines.Find(x =>
                        x.status == Status.Idle && x.machineData.product.productName ==
                        _seatWithOrders[i].order.productName);

                    if (!freeMachine) continue;
                    freeMachine.status = Status.InProgress;
                    waiter.SetUpProduct(_seatWithOrders[i].seat,freeMachine);
                    _seatWithOrders.RemoveAt(i);
                    break ;

                }
            }
        }
        
    }
}

[Serializable]
public class SeatWithOrder
{
    public Seat seat;
    public Order order;

    public SeatWithOrder(Seat seat, Order order)
    {
        this.seat = seat;
        this.order = order;
    }
}
