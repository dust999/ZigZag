using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Diamond : CollectableItem
{    
    [SerializeField] UnityEvent _collectEvent = null;
    [SerializeField] private ObjectPool _diamondFXPool = null;

    private void PlayDiamondFX()
    {
        if (_diamondFXPool == null) return;

        DiamondFX diamomdFX = (DiamondFX)_diamondFXPool.GetItem();
        if (diamomdFX == null) return;

        diamomdFX.transform.position = transform.position;
        diamomdFX.gameObject.SetActive(true);
        diamomdFX.DelayedDisable();
    }
        
    protected override void Collect()
    {
        _collectEvent?.Invoke();

        PlayDiamondFX();
        base.Collect();
    }
}
