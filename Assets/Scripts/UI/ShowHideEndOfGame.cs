using UnityEngine;
using UnityEngine.Events;

public class ShowHideEndOfGame : MonoBehaviour
{
    [SerializeField] private UnityEvent _showEndOfGame = null;
    [SerializeField] private UnityEvent _hideEndOfGame = null;
    public void HideEndOfGame()
    {
        _hideEndOfGame?.Invoke();
    }

    public void ShowEndOfGame()
    {
        _showEndOfGame?.Invoke();
    }
}
