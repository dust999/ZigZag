public class PlatformsPool : ObjectPool, IDifficultChangeable
{
    public int ActivePlatforms { get; private set; } = 0;
    private bool isNeedToReCreatePool = false;
    public override void ResetPool()
    {
        ActivePlatforms = 0;

        if (isNeedToReCreatePool) { 
            ClearPool();
            isNeedToReCreatePool = false;
        }

        for (int i = 0; i < _objects.Count; i++) {
            GamePlatform platform = (GamePlatform)_objects[i];
            platform.ResetPlatform();
            ActivateObject(_objects[i], false);
        }
    }
    protected override void ActivateObject(ClonableObject item, bool isActive = true)
    {

        GamePlatform platform = (GamePlatform)item;
        platform.ShowPlatform(isActive);
        
        if(isActive)
            ActivePlatforms++;
    }

    public void HidePlatformsIfOutOfView(float bottomEdgeOfGame)
    {
        foreach (Platform platform in _objects)
        {
            if (platform.transform.position.z > bottomEdgeOfGame) continue;
            
            if (platform.AnimatedDissapear())
                ActivePlatforms--;
        }
    }

    public void DifficultChange(DifficultLevel difficultLevel)
    {
        _pooledObject = difficultLevel.Platform;
        isNeedToReCreatePool = true;
    }
}
