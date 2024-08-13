using System.Collections;
using UnityEngine;

namespace UI
{
    public class BasePanel : MonoBehaviour
    {
        public UILayer uiLayer;
        public virtual void OnEnter()
        {
            transform.SetParent(UIManager.Instance.dicLayer[uiLayer]);
            gameObject.SetActive(true);
        }
        public virtual void OnPause()
        {
           
        }
        public virtual void OnResume()
        {

        }
        public virtual void OnExit()
        {
            gameObject.SetActive(false);
        }

    }
}