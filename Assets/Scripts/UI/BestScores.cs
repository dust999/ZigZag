using UnityEngine;
using UnityEngine.UI;

public class BestScores : MonoBehaviour
{
    [SerializeField] private GameObject _newHightScoreTitle = null;
    [SerializeField] private Text _scroesText = null;
    [SerializeField] private Text _bestScroesText = null;

    [SerializeField] private Scores _scoresInGame = null;

    private int _bestScores = 0;

    public void Awake()
    {
        if (_bestScroesText == null) return;

        _bestScores = PlayerPrefs.GetInt("bestScores", 0);
        _bestScroesText.text = _bestScores.ToString();
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("bestScores", _bestScores);
        PlayerPrefs.Save();
    }

    public void SetScores()
    {
        if (_scoresInGame == null) return;

        if (_scroesText == null) return;
        if (_bestScroesText == null) return;

        int scores = _scoresInGame.GetScore;

        if (_bestScores < scores) {
            _bestScores = scores;
            SaveBestScore();
            _newHightScoreTitle.SetActive(true);
        }

        _scroesText.text = scores.ToString();
        _bestScroesText.text = _bestScores.ToString();      
    }

    public void HideNewHightScoreTitle()
    {
        _newHightScoreTitle.SetActive(false);
    }
}
