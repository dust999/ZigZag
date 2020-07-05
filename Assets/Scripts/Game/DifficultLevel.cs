using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/DifficultLevel")]
public class DifficultLevel : ScriptableObject
{
    [SerializeField] private string _difficultName = "Difficult level Normal";
    [SerializeField] private GamePlatform _platform = null;
    [SerializeField] private int _gameFieldSize = 5;
    [SerializeField] private float _platformSize = 2f;
    [SerializeField] private float _statrtOffset = 2f;
    [SerializeField] private int _platformsVisibleRange = 30;

    [SerializeField] private PlaceOrder _diamonPlace = PlaceOrder.Random;
    [SerializeField] private int _maxPlacesInStack = 5;

    public GamePlatform Platform { get { return _platform; } }
    public int GameFieldSize { get { return _gameFieldSize; } }
    public float PlatformSize { get { return _platformSize; } }
    public float StatrtOffset { get { return _statrtOffset; } }
    public int PlatformsVisibleRange { get { return _platformsVisibleRange; } }
    public PlaceOrder DiamonPlace { get { return _diamonPlace; }  }
    public int MaxPlacesInStack { get { return _maxPlacesInStack; } }
}
