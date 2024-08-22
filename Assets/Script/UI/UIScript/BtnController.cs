using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject highLight;
    GameObject disabled;
    protected void Awake()
    {
        highLight = transform.GetChild(0).gameObject;
        disabled = transform.GetChild(2).gameObject;

        highLight.SetActive(false);
        disabled.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        highLight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        highLight.SetActive(false);
    }

    public void BtnDisable()
    {
        disabled.SetActive(true);
    }
}
