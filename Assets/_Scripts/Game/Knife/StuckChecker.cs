using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Scripts.Game.Knife
{
    public class StuckChecker : MonoBehaviour
    {
        private IStuckable _stuckableTarget;

        [Inject]
        private void Construct(IStuckable stuckable)
        {
            _stuckableTarget = stuckable;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 9)
                _stuckableTarget.TryToStuck();
        }
    }
}