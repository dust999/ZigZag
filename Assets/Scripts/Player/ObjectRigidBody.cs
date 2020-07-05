using System.Collections;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class ObjectRigidBody : MonoBehaviour
{
    private Rigidbody _rigidBody = null;
    [SerializeField] private float _speedOfFall = 3f;
    [SerializeField] private float _fallTime = 5f;
    private IEnumerator _disableDellay;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _disableDellay = DisableAnimation();
    }

    public void FallAway(Vector3 direction)
    {
        EanbleKinematic(false);
        _rigidBody.AddForce(direction * _speedOfFall, ForceMode.VelocityChange);

        StopCoroutine(_disableDellay);
        _disableDellay = DisableAnimation();
        StartCoroutine(_disableDellay);
    }

    private IEnumerator DisableAnimation()
    {
        yield return new WaitForSeconds(_fallTime);
        EanbleKinematic();
    }

    private void EanbleKinematic(bool isActive = true)
    {
        _rigidBody.isKinematic = isActive;
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
    }

    public void ResetRigidBody()
    {
        EanbleKinematic();
    }
}
