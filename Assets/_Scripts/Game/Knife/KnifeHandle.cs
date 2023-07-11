using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Game.Knife
{
    public class KnifeHandle : MonoBehaviour
    {
        private IFlippable _flippableTarget;

        [Inject]
        private void Construct(IFlippable flippable)
        {
            _flippableTarget = flippable;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _flippableTarget.BackFlip();
        }
    }
}