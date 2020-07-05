using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] string _sceneName = "Game";
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
