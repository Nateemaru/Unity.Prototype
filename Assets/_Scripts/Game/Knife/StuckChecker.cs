using DG.Tweening;
using UnityEngine;

namespace _Scripts.Game.Knife
{
    public class StuckChecker : MonoBehaviour
    {
        [SerializeField] private Rigidbody _parentRigidbody;

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
                _parentRigidbody.isKinematic = true;
                _parentRigidbody.transform.DOKill();
            }
        }
    }
}