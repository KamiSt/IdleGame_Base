using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public SOMachine machineData;
    public Waiter waiter;
    public Status status = Status.Idle;
}
