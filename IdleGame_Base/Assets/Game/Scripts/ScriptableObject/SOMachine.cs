using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SOMachine : ScriptableObject
{
   public string id;
   public string machineName;
   public float baseTimeToMade;
   public SOProduct product;

}
