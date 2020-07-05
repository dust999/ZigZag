using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SwitchImageColor : MonoBehaviour
{
    private Image _image = null;

    [SerializeField] private Color active = Color.white;
    [SerializeField] private Color disabled = Color.gray;
    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SwitchColor(bool isActive)
    {
        if (isActive)
            _image.color = active;
        else
            _image.color = disabled;
    }
}
