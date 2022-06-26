using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Seat seat;
    public Transform exitPos;
    public CustomerStatus customerStatus;

    public void SetUp(Seat seat, Transform exitPos)
    {
        this.seat = seat;
        this.exitPos = exitPos;
        customerStatus = CustomerStatus.Nothings;
    }

}

