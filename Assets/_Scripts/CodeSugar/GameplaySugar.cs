using System;
using DG.Tweening;

namespace _Scripts.CodeSugar
{
    public static class GameplaySugar
    {
        public static Tween AfterCall(this float delay, Action action)
        {
            if (delay == 0)
            {
                action?.Invoke();
                return DOVirtual.DelayedCall(0, () => { });
            }

            return DOVirtual.DelayedCall(delay, () => action?.Invoke());
        }
    }
}