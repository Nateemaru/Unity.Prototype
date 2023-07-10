using System;
using _Scripts.Services.InputService;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using Zenject;

namespace _Scripts.Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponFlipper : MonoBehaviour
    {
        [SerializeField] private Vector3 _movementDirection;
        [SerializeField] private float _flipForce;
        private IInputService _inputService;
        private Rigidbody _rb;
        private bool _isFlipping;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.centerOfMass = Vector3.zero;

            _inputService.OnTouched += Flip;
        }

        private void OnDisable()
        {
            _inputService.OnTouched -= Flip;
        }

        private void Flip()
        {
            _rb.isKinematic = false;
            _rb.velocity = _movementDirection;
            _rb.AddTorque(Vector3.right * _flipForce, ForceMode.Impulse);
        }
    }
}
