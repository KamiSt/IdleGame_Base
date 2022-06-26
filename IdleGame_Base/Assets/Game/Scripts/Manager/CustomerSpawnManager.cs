using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnManager : MonoBehaviour
{
   [SerializeField] private Transform SpawnPos;
   [SerializeField] private GameObject customerPrefab;

   private List<Seat> spawnWorkList=new List<Seat>();
   private float timeSpend=0;
   private Status _status=Status.Idle;
   public void OnEnable()
   {
      EventManager.OnRequestSpawnCustomer +=ReceivedRequestSpawnCustomer;
   }

 

   private void OnDisable()
   {
      EventManager.OnRequestSpawnCustomer -=ReceivedRequestSpawnCustomer;
   }
   
   private void ReceivedRequestSpawnCustomer(Seat seat)
   {
      spawnWorkList.Add(seat);
      _status = Status.InProgress;
   }

   private void Update()
   {
      if (_status != Status.InProgress) return;
      timeSpend += Time.deltaTime;
      if (!(timeSpend > 5)) return;
      timeSpend = 0;
      InstantiateCustomer(spawnWorkList[0]);
      spawnWorkList.RemoveAt(0);
      _status = spawnWorkList.Count == 0 ? Status.Idle : Status.InProgress;
   }

   private void InstantiateCustomer(Seat seat)
   {
      
      var customer=Instantiate(customerPrefab, SpawnPos.position, Quaternion.identity).GetComponent<Customer>();
      customer.SetUp(seat,SpawnPos);
   }
}

public enum Status
{
   Idle,
   InProgress,

}