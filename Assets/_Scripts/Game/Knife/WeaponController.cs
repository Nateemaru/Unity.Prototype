using System;
using _Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Scripts.Game.Knife
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponController : MonoBehaviour, IFlippable, IStuckable
    {
        [SerializeField] private Vector3 _movementDirection;
        [SerializeField] private float _flipForce;
        [SerializeField] private Transform _centreOfMassPoint;
        private IInputService _inputService;
        private Rigidbody _rb;
        private bool _canStuck = true;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.maxAngularVelocity = Mathf.Infinity;
            _rb.centerOfMass = Vector3.Scale(_centreOfMassPoint.localPosition, transform.localScale);
            _rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

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
                if (HasFinishedRotation() && IsLookingAtForward())
                    ResetGroundPosition();
            }
            
            if(_canStuck && IsLookingAtForward())
                _rb.maxAngularVelocity = 2f;
            else
                _rb.maxAngularVelocity = 10f;
        }

        private void FixedUpdate()
        {
            _rb.inertiaTensorRotation = Quaternion.identity;
        }

        private bool IsFalling() => _rb.velocity.y < 0;

        private bool HasFinishedRotation() => Math.Abs(transform.rotation.eulerAngles.x - 15.0f) < 5.0f;

        private bool IsLookingAtForward() => Vector3.Angle(transform.up, Vector3.up) < 30f;

        private void ResetGroundPosition() => _rb.angularVelocity = new Vector3(0.5f, 0, 0);
        
        private void DisableStucking() => _canStuck = true;

        public void TryToStuck()
        {
            if (_canStuck)
                _rb.isKinematic = true;
        }

        public void Flip()
        {
            _canStuck = false;
            _rb.isKinematic = false;
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = _movementDirection;
            _rb.AddTorque(transform.right * _flipForce, ForceMode.VelocityChange);
            Invoke(nameof(DisableStucking), 0.4f);
        }
        
        public void BackFlip()
        {
            _rb.isKinematic = false;
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = new Vector3(0, _movementDirection.y / 2, -_movementDirection.z);
            _rb.AddTorque(-transform.right * _flipForce, ForceMode.VelocityChange);
        }
    }
}
