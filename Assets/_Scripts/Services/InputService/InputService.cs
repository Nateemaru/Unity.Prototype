using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Services.InputService
{
    public class InputService : MonoBehaviour, IInputService
    {
        public Action<Vector3> GetPositionOnTouched { get; set; }
        public Action OnTouched { get; set; }

        private bool _isMobile;

        private void Start()
        {
            if (Application.isMobilePlatform)
                _isMobile = true;
        }

        private void OnDisable()
        {
            GetPositionOnTouched = null;
            OnTouched = null;
        }

        private void Update()
        {
            if (_isMobile)
                ReadScreenTouches();
            else
                ReadMouseButton();
        }
        
        public void Reset()
        {
            GetPositionOnTouched = null;
            OnTouched = null;
        }

        private void ReadMouseButton()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                GetPositionOnTouched?.Invoke(Input.mousePosition);
                OnTouched?.Invoke();
            }
        }

        private void ReadScreenTouches()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
                                     && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                
                GetPositionOnTouched?.Invoke(Input.GetTouch(0).position);
                OnTouched?.Invoke();
            }
        }
    }
}