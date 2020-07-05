using System.Collections;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Material _material = null;
    [SerializeField] private Gradient _gradient = new Gradient();
    [SerializeField] private float _timeToChangeColor = 30f;

    private IEnumerator _currentAnimation = null;
    private float _lastTime = 0f;

    public void Start()
    {
        if (_gradient == null) return;

        StartAnimation();
    }

    private void StopAnimation()
    {
        if (_currentAnimation == null) return;
        StopCoroutine(_currentAnimation);
    }

    private void StartAnimation()
    {
        StopAnimation();
        _currentAnimation = ChangeColorAnimation();
        StartCoroutine(_currentAnimation);
    }

    private IEnumerator ChangeColorAnimation()
    {
        _lastTime = Time.time + _timeToChangeColor;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        float progress = 0;
        
        while (Time.time < _lastTime)
        {
            progress = 1 - (_lastTime - Time.time)/ _timeToChangeColor;
            _material.color = _gradient.Evaluate(progress);
            
            yield return waitForEndOfFrame;
        }

        StartAnimation();
    }

    public void Reset()
    {
        StopAnimation();
        _material.color = _gradient.Evaluate(0);
        StartAnimation();
    }

    private void OnDestroy()
    {
        StopAnimation();
        _material.color = _gradient.Evaluate(0);
    }
}
