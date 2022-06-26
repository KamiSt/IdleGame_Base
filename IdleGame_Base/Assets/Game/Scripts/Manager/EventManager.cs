using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class EventManager : MonoBehaviour
{
   #region RequestSpawnCustomer

   public delegate void RequestSpawnCustomerHandler(Seat seat);

   public static event RequestSpawnCustomerHandler OnRequestSpawnCustomer;

   public static void RequestSpawnCustomer(Seat seat)
   {
      OnRequestSpawnCustomer?.Invoke(seat);
   }

   #endregion

   #region RequestOrdering
   public delegate void RequestOrderingHandler(Seat seat);

   public static event RequestOrderingHandler OnRequestOrdering;

   public static void RequestOrdering(Seat seat)
   {
      OnRequestOrdering?.Invoke(seat);
   }


   #endregion

   #region ChangeSeatStatus

   public delegate void ChangeSeatStatusHandler();

   public static event ChangeSeatStatusHandler OnChangeSeatStatus;

   public static void ChangeSeatStatus()
   {
      OnChangeSeatStatus?.Invoke();
   }


   #endregion

   #region RequestMakingProduct

   public delegate void RequestMakingProductHandler(Seat seat);

   public static event RequestMakingProductHandler OnRequestMakingProduct;

   public static void RequestMakingProduct(Seat seat)
   {
      OnRequestMakingProduct?.Invoke(seat);
   }

   #endregion
}
