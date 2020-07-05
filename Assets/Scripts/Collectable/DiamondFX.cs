using UnityEngine;
using System.Collections;

public class DiamondFX : ClonableObject
{
    public override object Clone()
    {
        GameObject newItem = Instantiate(gameObject);
        DiamondFX diamondFX = newItem.GetComponent<DiamondFX>();
        return diamondFX;
    }

    public void DelayedDisable()
    {
        StartCoroutine(DissableDiamondFX());
    }

    private IEnumerator DissableDiamondFX()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
