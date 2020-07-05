using System.Collections;
using UnityEngine;

public class Platform : GamePlatform
{
    [SerializeField] private float _hiddingOffsetY = -10f;
    [SerializeField] private float _animationTime = 1f;
    [SerializeField] private AnimationCurve _animationCurve = null;

    private IEnumerator _animation = null;
    public bool _isAnimated = false;

    private void Awake()
    {
        _animation = HideAnimation();
    }

    public override void ShowPlatform(bool isShow = true)
    {
        if (_isAnimated) return;
        
        base.ShowPlatform(isShow);
    }

    public bool AnimatedDissapear()
    {
        if (_animation == null) return false;
        if (_isAnimated || !gameObject.activeInHierarchy) return false;

        _animation = HideAnimation();
        StartCoroutine(_animation);
        return true;
    }

    public override void ResetPlatform()
    {
        _isAnimated = false;
        
        if(_animation != null)
            StopCoroutine(_animation);
        
        base.ResetPlatform();        
    }

    private IEnumerator HideAnimation()
    {
        _isAnimated = true;
        float timeToAnimation = Time.time + _animationTime;

        Vector3 animatedPosition = transform.position;
        float startY = animatedPosition.y;
        
        float progress = 0f;

        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        while(Time.time <= timeToAnimation)
        {
            progress = 1 - (timeToAnimation - Time.time) / _animationTime;
            animatedPosition.y = startY + (_hiddingOffsetY-startY) * _animationCurve.Evaluate(progress);
            transform.position = animatedPosition;

            yield return waitForEndOfFrame;
        }

        animatedPosition.y = _hiddingOffsetY;
        transform.position = animatedPosition;
        
        _isAnimated = false;

        base.ShowPlatform(false);
    }
}
