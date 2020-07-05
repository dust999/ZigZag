using UnityEngine;

public abstract class GamePlatform : ClonableObject
{
    public virtual void ShowPlatform(bool isActive = true) {
        gameObject.SetActive(isActive);
    }

    public virtual void ResetPlatform()
    {
        transform.position = Vector3.zero;
    }

    public override object Clone()
    {
        GameObject newItem = Instantiate(gameObject);
        GamePlatform gamePlatform = newItem.GetComponent<GamePlatform>();
        return gamePlatform;
    }
}