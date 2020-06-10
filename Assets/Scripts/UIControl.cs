﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl instance { get; private set; }
    public Image mask;
    private float originalSize;
    
    void Awake() 
    {
        instance=this; 
    }
    
    void Start()
    {
        originalSize=mask.rectTransform.rect.width;    
    }

    public void SetValue(float value) 
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize*value); 
    }
}
