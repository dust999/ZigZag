using System.Collections.Generic;
using UnityEngine;

public class RandomPlace : IPlaceable
{
    public void Place(List<Vector3> places, ObjectPool objectPool, int currentPosition)
    {
        for( int i = 0; i < places.Count; i++)
        {
            if (Random.Range(0, 2) == 0) continue;

            Diamond diamond = (Diamond) objectPool.GetItem();
            if (diamond == null) return;

            diamond.transform.position = places[i];
            diamond.gameObject.SetActive(true);
        }
    }
}
