using UnityEngine;

[RequireComponent(typeof(PlatformsPool))]
public class LevelGenerator : MonoBehaviour, IDifficultChangeable
{
    [SerializeField] private int _fieldSize = 5;
    [SerializeField] private float _startOffset = 2;
    [SerializeField] private Platform _startPlatforms = null;

    private PlatformsPool _platformsPool = null;
    [SerializeField] private float _platformSize = 2f;
    [SerializeField] private float _platformHiddingOffset = 14f;
    [SerializeField] private int _platformsVisibleRange = 30;

    private Vector3 _lastPlatformPosition = Vector3.zero;

    [SerializeField] private Transform _player = null;

    [SerializeField] private DiamondsGenerator _diamondGenerator = null;


    private void Awake()
    {
        _platformsPool = GetComponent<PlatformsPool>();
        
    }
    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        Vector3 startPosition = Vector3.zero;
        startPosition.z += _startOffset;       

        _lastPlatformPosition = startPosition;

        ResetPlatforms();
        GenerateLevel();
    }

    private void ResetPlatforms()
    {
        _startPlatforms.ResetPlatform();
        _startPlatforms.ShowPlatform();
    }

    public void GenerateLevel()
    {
        if (_platformsPool == null) return;
        if (_platformsVisibleRange < 1) return;

        Direction direction = Direction.Forward;

        for (int i = 0; i < _platformsVisibleRange; i++)
        {
            PlacePlatform(AddNextPlatform(), direction);
            direction = Direction.Random;
        }
    }

    private GamePlatform AddNextPlatform()
    {
        GamePlatform platform = (GamePlatform)_platformsPool.GetItem();       
        if (platform == null) return null;

        platform.transform.position = Vector3.zero;
        platform.transform.localEulerAngles = Vector3.zero; // FIX ROTATION

        return platform;
    }

    private void PlacePlatform(GamePlatform platform, Direction direction = Direction.Random)
    {
        if (platform == null) return;

        if (direction == Direction.Random)
            direction = Random.Range(0, 2) == 0 ? Direction.Forward : Direction.Right;

        if (direction == Direction.Right)
            _lastPlatformPosition.x += _platformSize;
        else
            _lastPlatformPosition.z += _platformSize;

        platform.transform.localPosition = _lastPlatformPosition;

        FixPlatformOutSideField(platform);
       //Debug.Log(platform.transform.position + " " + direction + " "+ platform.gameObject);

        _diamondGenerator.AddDiamondPositionInStack(platform.transform.position);
    }

    private void FixPlatformOutSideField(GamePlatform platform)
    {
        Vector3 platformPosition = platform.transform.position;

        if (platformPosition.x <= -_fieldSize) // LEFT EDGE
            ReplaceLastPositionInsideField(Direction.Right);

        else if (platformPosition.x > _fieldSize) // RIGHT EDGE
            ReplaceLastPositionInsideField(Direction.Forward);

        platform.transform.localPosition = _lastPlatformPosition;
    }

    private void ReplaceLastPositionInsideField(Direction moveToDirection = Direction.Right)
    {
        int direction = moveToDirection == Direction.Right ? 1 : -1;

        _lastPlatformPosition.z -= direction * _platformSize;
        _lastPlatformPosition.x += direction * _platformSize;
    }

    private void Update()
    {
        HidePlatforms();
        PlaceNewPlatform();
    }

    private void HidePlatforms()
    {
        float bottomEdgeOfGame = _player.transform.position.z - _platformHiddingOffset;

        if (_startPlatforms.transform.position.z < bottomEdgeOfGame)
        {
            _startPlatforms.AnimatedDissapear();
        }

        _platformsPool.HidePlatformsIfOutOfView(bottomEdgeOfGame);
    }

    private void PlaceNewPlatform()
    {
        if (_platformsPool.ActivePlatforms > _platformsVisibleRange) return;
        
        PlacePlatform(AddNextPlatform());
    }

    public void DifficultChange(DifficultLevel difficultLevel)
    {
        _fieldSize = difficultLevel.GameFieldSize;
        _startOffset = difficultLevel.StatrtOffset;
        _platformSize = difficultLevel.PlatformSize;
        _platformsVisibleRange = difficultLevel.PlatformsVisibleRange;
    }
}