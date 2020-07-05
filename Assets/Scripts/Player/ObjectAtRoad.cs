using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ObjectAtRoad : MonoBehaviour
{
    private int _contacts = 0;
    public UnityEvent objectOutOfRoad = null;

    public void Reset()
    {
        _contacts = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _contacts++;
    }

    private void OnTriggerExit(Collider other)
    {
        _contacts--;

        if (_contacts > 0) return;

        objectOutOfRoad?.Invoke();        
    }
}
