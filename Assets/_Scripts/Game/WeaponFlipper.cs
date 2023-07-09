using System;
using _Scripts.Services.InputService;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Scripts.Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponFlipper : MonoBehaviour
    {
        [SerializeField] private float _flipForce;
        private IInputService _inputService;
        private Rigidbody _rb;

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
            _rb.velocity = new Vector3(0, 8, 4);
            _rb.AddRelativeTorque(new Vector3(90,0, 0), ForceMode.Impulse);
        }
    }
}
