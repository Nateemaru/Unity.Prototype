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
        [SerializeField] private Vector3 _movementDirection;
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
            _rb.velocity = _movementDirection;
            transform.DOLocalRotate(new Vector3(360, 0, 0), 1, RotateMode.LocalAxisAdd);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 9)
            {
                Debug.Log("hel");
            }
        }
    }
}
