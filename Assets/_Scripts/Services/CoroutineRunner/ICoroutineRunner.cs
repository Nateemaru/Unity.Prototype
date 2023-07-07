using System.Collections;
using UnityEngine;

namespace _Scripts.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}