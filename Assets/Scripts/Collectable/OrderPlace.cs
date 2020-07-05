using System.Collections.Generic;
using UnityEngine;

public class OrderPlace : IPlaceable
{
    public void Place(List<Vector3> places, ObjectPool objectPool, int currentPosition)
    {
        if (currentPosition > places.Count) return;
        
        for (int i = 0; i < places.Count; i++)
        {
            if (i != currentPosition) continue;

            Diamond diamond = (Diamond) objectPool.GetItem();
            diamond.transform.position = places[i];
            diamond.gameObject.SetActive(true);
            return;
        }
    }
}
