using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent gameStart;
    public UnityEvent gameEnd;
    public UnityEvent itemCollected;

    public int currentDifficult = 1;
    public DifficultLevel[] difficultLevel = null;

    private bool _isGameEnded = false;
    
    public void GameStart()
    {
        _isGameEnded = false;
        gameStart?.Invoke();
    }

    public void GameEnd()
    {
        if (_isGameEnded) return;
        _isGameEnded = true;

        gameEnd?.Invoke();
        
    }

    public void ItemCollected()
    {
        itemCollected?.Invoke();
    }

}
