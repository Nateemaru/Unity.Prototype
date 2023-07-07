using System;

namespace _Scripts.Services.Database
{
    [Serializable]
    public class TrackableValue<T> : ITrackableValue
    {
        public event Action<T> OnValueChangedWithReturn;
        public event Action OnValueChanged;

        public virtual T Value
        {
            get
            {
                if (_firstGet != null && !_firstGetExecuted)
                {
                    _value = _firstGet();
                    _firstGetExecuted = true;
                }

                return _value;
            }
            set
            {
                if (_firstGet != null && !_firstGetExecuted)
                {
                    _value = _firstGet();
                    _firstGetExecuted = true;
                }
                
                if (!_value.Equals(value))
                {
                    _value = value;
                    OnValueChangedWithReturn?.Invoke(value);
                    OnValueChanged?.Invoke();
                }
            }
        }
        private T _value;
        private Func<T> _firstGet;
        private bool _firstGetExecuted;

        public TrackableValue(T value, Func<T> firstGet = null)
        {
            _value = value;
            _firstGet = firstGet;
        }
    }
}