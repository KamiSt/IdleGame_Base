using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TableManager : MonoBehaviour
{
    [SerializeField] private float delayStartTime;
    [SerializeField] private List<Table> tables;

    
    private void Start()
    {

        CheckTableStatus();
    }



    private void OnEnable()
    {
        EventManager.OnChangeSeatStatus += CheckTableStatus;
    }

    private void OnDisable()
    {
        EventManager.OnChangeSeatStatus -= CheckTableStatus;
    }

    private void CheckTableStatus()
    {
        foreach (var seat in tables.SelectMany(table => table.seats))
        {
            if (seat.seatStatus == SeatStatus.NoCustomer)
            {
                seat.seatStatus = SeatStatus.CustomerReserved;
                EventManager.RequestSpawnCustomer(seat);
            }

            else if (seat.seatStatus == SeatStatus.CustomerSeated && seat.orderEnum == OrderEnum.NoOrder)
            {
            
                seat.orderEnum = OrderEnum.Ordering;
                EventManager.RequestOrdering(seat);
                
            }

            else if (seat.seatStatus == SeatStatus.CustomerSeated && seat.orderEnum == OrderEnum.Ordered)
            {
         
                seat.orderEnum = OrderEnum.WaitingForProduct;
                EventManager.RequestMakingProduct(seat);
                
            }
        }
    }
}
