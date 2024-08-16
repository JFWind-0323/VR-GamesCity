using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BNG {

    /// <summary>
    /// This script will toggle a GameObject whenever the provided InputAction is executed
    /// </summary>
    public class ToggleActiveOnInputAction : MonoBehaviour {

        public InputActionReference InputAction = default;
        public GameObject ToggleObject = default;
        public bool IsActive = false;

        private void OnEnable() {
            InputAction.action.performed += ToggleActive;
        }

        private void OnDisable() {
            InputAction.action.performed -= ToggleActive;
        }

        public void ToggleActive(InputAction.CallbackContext context) {
            if (!IsActive)
            {
                UIManager.Instance.PushPanel(UIType.MenuPanel);
                CanvasTrack.Instance.Track();
                IsActive = true;
            }
            else
            {
                UIManager.Instance.PopPanel();
                if (UIManager.Instance.GetTopPanel() == null)
                {
                    IsActive = false;
                }
               
            }
           
            //if(ToggleObject) {
            //    ToggleObject.SetActive(!ToggleObject.activeSelf);
            //}
        }
    }
}

