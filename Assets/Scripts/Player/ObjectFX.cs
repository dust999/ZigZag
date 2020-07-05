using UnityEngine;

public class ObjectFX : MonoBehaviour
{
    // THERE CAN BE ARRAYS
    [SerializeField] private TrailRenderer _trail = null;
    [SerializeField] private ParticleSystem _particles = null;

    private void EnableFX(bool isEnabled = true)
    {
        if (_particles != null)
        {
            if (isEnabled)
                _particles.Play();
            else
                _particles.Stop();
        }

        if (_trail != null)
            _trail.enabled = isEnabled;
    }
    private void EnableFXDelayed() // NEED FOR EASY CALL FROM INVOKE
    {
        EnableFX(true);
    }

    public void ResetFX()
    {
        EnableFX(false);

        // NEED DELAY TO REMOVE TRAIL FX WHILE RESET PLAYER POSITION AT START
        Invoke(nameof(EnableFXDelayed), 1f);
    }
}
