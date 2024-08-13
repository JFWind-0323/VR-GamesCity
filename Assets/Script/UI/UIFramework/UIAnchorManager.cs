using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchorManager : MonoSingle<UIAnchorManager>
{
    public void FillTheCanvas(RectTransform tf)
    {
       tf.anchorMin = Vector2.zero;
       tf.anchorMax = new Vector2(1, 1);
       tf.offsetMin = Vector2.zero;
       tf.offsetMax = Vector2.zero;
    }
}
