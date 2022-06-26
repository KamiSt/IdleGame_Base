using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Order
{
   public string productName;


   public Order(string productName)
   {
      this.productName = productName;
   }
}
