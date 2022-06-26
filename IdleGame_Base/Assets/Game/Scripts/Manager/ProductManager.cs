using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public List<SOProduct> Products;

    public List<Order> GetRandomOrder()
    {
        var index=Random.Range(0,Products.Count);

        var orders = new List<Order>();
        orders.Add( new Order(Products[index].productName));
        return orders;
    }
}
