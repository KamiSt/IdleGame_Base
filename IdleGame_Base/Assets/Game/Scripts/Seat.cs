using System;
using System.Collections.Generic;
using UnityEngine;



public class Seat :MonoBehaviour
{
    [Header("POS")]
    public Transform customerPos;
    public Transform waiterPos;
    
    [Header("Dont Edit this")]
    public Customer customer;
    public List<Order> orders;
    public OrderEnum orderEnum;
    public SeatStatus seatStatus;

    public void ChangeSeatStatus(SeatStatus newSeatStatus,Customer customer)
    {
        if (newSeatStatus == SeatStatus.CustomerSeated)
        {
            this.customer=customer ;
        }
      
        seatStatus = newSeatStatus;
        EventManager.ChangeSeatStatus();
    }

    public void Ordering()
    {
        orderEnum = OrderEnum.Ordering;
        customer.ChangeStatus( CustomerStatus.Ordering);
        EventManager.ChangeSeatStatus();
    }
    public void Ordered()
    {
        orderEnum = OrderEnum.Ordered;
        orders=FindObjectOfType<ProductManager>().GetRandomOrder();
        customer.ChangeStatus(CustomerStatus.Ordered,FindObjectOfType<ProductManager>().Products[0]);
       
        EventManager.ChangeSeatStatus();
        
    }

    public void ReceiveOrder(SOProduct product)
    {
        var a = orders.FindIndex(x => x.productName == product.productName);
        orders.RemoveAt(a);
        if (orders.Count != 0) return;
        seatStatus = SeatStatus.NoCustomer;
        orderEnum = OrderEnum.NoOrder;
        customer.ChangeStatus( CustomerStatus.ReceiveOrdered);
        EventManager.ChangeSeatStatus();
    }
}
