using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected ClonableObject _pooledObject = null;
    [SerializeField] protected List<ClonableObject> _objects = new List<ClonableObject>();
    [SerializeField] private bool _isIncreasingPool = false;

    private void Awake()
    {
        ResetPool();
    }

    public virtual void ResetPool()
    {
        for (int i = 0; i < _objects.Count; i++)
            ActivateObject(_objects[i], false);
    }

    public void ClearPool()
    {
        RemoveAllItems();
        _objects = new List<ClonableObject>();
    }

    public virtual ClonableObject GetItem()
    {
        for(int i = 0; i < _objects.Count; i++)
        {
            if (!_objects[i].gameObject.activeSelf)
            {
                ActivateObject(_objects[i]);
                return _objects[i];
            }
        }

        if (_isIncreasingPool)
        {
            return MakeNewItem();
        }

        return null;
    }

    private ClonableObject MakeNewItem()
    {
        if (_pooledObject == null) return null;
        
        ClonableObject newItem = (ClonableObject) _pooledObject.Clone();
        newItem.transform.parent = transform;
        _objects.Add(newItem);
        ActivateObject(newItem);
        return newItem;   
    }

    protected virtual void ActivateObject(ClonableObject item, bool isActive = true)
    {
        item.gameObject.SetActive(isActive);
    }

    private void RemoveAllItems()
    {
        foreach (ClonableObject obj in _objects)
        {
            Destroy(obj.gameObject);           
        }

        _objects = null;
    }
}
