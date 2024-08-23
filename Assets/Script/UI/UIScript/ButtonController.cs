using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int typeID;

    Sprite[] hlSprites;
    Sprite[] dbSprites;

    GameObject highLight;
    GameObject disabled;

    Image hlImage;
    Image dbImage;


    protected void Awake()
    {
        hlSprites = Resources.LoadAll<Sprite>("Sprites/GoodsSprite/Highlight");
        dbSprites = Resources.LoadAll<Sprite>("Sprites/GoodsSprite/Disable");

        highLight = transform.GetChild(0).gameObject;
        disabled = transform.GetChild(2).gameObject;

        hlImage = highLight.GetComponent<Image>();
        dbImage = disabled.GetComponent<Image>();

        highLight.SetActive(false);
        disabled.SetActive(false);
       
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        if (typeID == 0)
        {
            hlImage.rectTransform.sizeDelta = new Vector2(600, 200);
            dbImage.rectTransform.sizeDelta = new Vector2(600, 200);
        }
        else if (typeID == 1)
        {
            hlImage.rectTransform.sizeDelta = new Vector2(250, 250);
            dbImage.rectTransform.sizeDelta = new Vector2(250, 250);
        }

        hlImage.sprite = hlSprites[typeID];
        highLight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highLight.SetActive(false);
    }

    public void BtnDisable()
    {
        dbImage.sprite = dbSprites[typeID];
        disabled.SetActive(true);
    }
}
