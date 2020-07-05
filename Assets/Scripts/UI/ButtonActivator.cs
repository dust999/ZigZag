using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField] private Button _button = null;
    
    public void EnableButton()
    {
        if (_button == null) return;

        _button.enabled = !_button.enabled;
    }
 }
