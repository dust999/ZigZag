using System.Collections.Generic;
using UnityEngine;

public interface IPlaceable
{
    void Place(List<Vector3> places, ObjectPool objectPool, int currentPosition);
}
