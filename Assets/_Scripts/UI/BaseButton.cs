using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        protected Button _button;
        
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        public abstract void OnButtonClicked();
    }
}