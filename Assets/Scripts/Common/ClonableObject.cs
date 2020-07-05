using UnityEngine;

public class ClonableObject : MonoBehaviour, IClonable
{
    public virtual object Clone() { return new object(); }

}
