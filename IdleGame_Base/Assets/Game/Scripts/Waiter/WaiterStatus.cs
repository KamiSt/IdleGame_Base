using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaiterStatus 
{
   Idle,
   GoToOrdering,
   Ordering,
   GoToMachine,
   MakeProduct,
   HandOver,
}
