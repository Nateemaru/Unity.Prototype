using System;
using _Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Scripts.Game.Knife
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponFlipper : MonoBehaviour
    {
        [SerializeField] private Vector3 _movementDirection;
        [SerializeField] private float _flipForce;
        private IInputService _inputService;
        private Rigidbody _rb;
        private bool _allowJump;
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.maxAngularVelocity = Mathf.Infinity;

            _inputService.OnTouched += Flip;
        }

        private void OnDisable()
        {
            _inputService.OnTouched -= Flip;
        }

        private void Update()
        {
            if (IsFalling())
            {
                if (HasFinishedRotation())
                    ResetGroundPosition();
                else
                    _allowJump = false;
            }
        }

        private bool IsFalling()
        {
            return _rb.velocity.y < 0;
        }

        private bool HasFinishedRotation() => Math.Abs(transform.rotation.eulerAngles.x - 15.0f) < 5.0f &&
            Vector3.Angle(transform.up, Vector3.up) < 30f;

        private void ResetGroundPosition()
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
            _allowJump = true;
        }

        private void Flip()
        {
            _rb.isKinematic = false;
            _rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = _movementDirection;
            _rb.AddTorque(transform.right * _flipForce, ForceMode.VelocityChange);
        }
    }
}
