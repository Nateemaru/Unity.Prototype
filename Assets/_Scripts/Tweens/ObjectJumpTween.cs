using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Tweens
{
    public class ObjectJumpTween : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _duration;

        private void Start()
        {
            transform
                .DOMoveY(transform.position.y + _jumpForce, _duration)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}