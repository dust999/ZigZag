using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectableItem : ClonableObject
{
    public override object Clone()
    {
        GameObject newItem = Instantiate(gameObject);
        CollectableItem collectableItem = newItem.GetComponent<CollectableItem>();
        return collectableItem;
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    { 
        Collect();
    }
}