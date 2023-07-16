using System;
using _Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Scripts.Game.Knife
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IFlippable, IStuckable, IPlayer
    {
        [SerializeField] private Vector3 _movementDirection;
        [SerializeField] private float _flipForce;
        [SerializeField] private Transform _centreOfMassPoint;
        
        private IInputService _inputService;
        private Rigidbody _rb;
        private bool _canStuck = true;
        private bool _canFlip = true;
        private Vector3 _backMovement;

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
            
            _backMovement = new Vector3(0, _movementDirection.y / 2, -_movementDirection.z);

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

        private void EnableStucking() => _canStuck = true;

        private void FreezeStucking()
        {
            _canStuck = false;
            Invoke(nameof(EnableStucking), 0.4f);
        }

        private void ResetRigidbody(bool isKinematic = false)
        {
            _rb.isKinematic = isKinematic;
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }

        public void TryToStuck()
        {
            if (_canStuck)
                ResetRigidbody(true);
        }

        public void Flip()
        {
            if (_canFlip)
            {
                ResetRigidbody();
                _rb.AddForce(_movementDirection, ForceMode.Impulse);
                _rb.AddTorque(transform.right * _flipForce, ForceMode.VelocityChange);
                FreezeStucking();
            }
        }
        
        public void BackFlip()
        {
            if (_canFlip)
            {
                ResetRigidbody();
                _rb.AddForce(_backMovement, ForceMode.Impulse);
                _rb.AddTorque(-transform.right * _flipForce, ForceMode.VelocityChange);
            }
        }

        public void Die()
        {
            _canFlip = false;
            _inputService.OnTouched -= Flip;
            _rb.useGravity = false;
            ResetRigidbody(true);
            _rb.constraints = RigidbodyConstraints.None;
        }
    }
}
