using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    
    [SerializeField] private Image image;
    [SerializeField] private GameObject spriteParent;
    
    [SerializeField] private Sprite iconWaiting;
    [SerializeField] private Sprite iconOrdering;
    [SerializeField] private List<Sprite> iconHappy;


    public Seat seat;
    public Transform exitPos;

    
    
    

    private CustomerStatus _customerStatus;
    public void SetUp(Seat seat, Transform exitPos)
    {
        this.seat = seat;
        this.exitPos = exitPos;
        _customerStatus = CustomerStatus.Nothings;
    }

    public void ChangeStatus(CustomerStatus customerStatus,SOProduct product=null)
    {
        _customerStatus = customerStatus;
        switch (customerStatus)
        {
            case CustomerStatus.Nothings:
                spriteParent.SetActive(false);
                break;
            case CustomerStatus.Seated:
                spriteParent.SetActive(true);
                image.sprite = iconWaiting;
                break;
            case CustomerStatus.Ordering:
                spriteParent.SetActive(true);
                image.sprite = iconOrdering;
                break;
            case CustomerStatus.Ordered:
                spriteParent.SetActive(true);
                image.sprite = product.icon;
                break;
            case CustomerStatus.ReceiveOrdered:
                spriteParent.SetActive(true);
                var index = Random.Range(0, iconHappy.Count);
                image.sprite = iconHappy[index];
                break;
            case CustomerStatus.Complete:
                spriteParent.SetActive(false);
                
                break;
         
           
        }
    }

    public CustomerStatus GetCustomerStatus()
    {
        return _customerStatus;
    }

}

