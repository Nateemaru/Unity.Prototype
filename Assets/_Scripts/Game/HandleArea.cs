using UnityEngine;

namespace _Scripts.Game
{
    public class HandleArea : MonoBehaviour
    {
        [SerializeField] private Rigidbody _parentRigidbody;
        [SerializeField] private float _ricochetForce;

        private void Start()
        {
            if(!_parentRigidbody)
            {
                if (transform.parent.TryGetComponent(out Rigidbody parentRigidbody))
                    _parentRigidbody = parentRigidbody;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 9)
            {
                _parentRigidbody.isKinematic = false;
                _parentRigidbody.AddForce(Vector3.back * _ricochetForce, ForceMode.Impulse);
            }
        }
    }
}