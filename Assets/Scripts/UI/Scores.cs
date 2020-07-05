using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Scores : MonoBehaviour
{
    private Text _scores = null;
    [SerializeField] private int _scoreStep = 1;
    public int GetScore { get; private set; } = 0;

    private void Awake()
    {
        _scores = GetComponent<Text>();
        ResetScores();
    }

    public void UpdateScore()
    {
        GetScore += _scoreStep;
        _scores.text = GetScore.ToString();
    }

    public void ResetScores()
    {
        _scores.text = "0";
        GetScore = 0;
    }
}
