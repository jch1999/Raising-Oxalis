using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl instance { get; private set; }
    public Image state;
    
    void Awake() 
    {
        instance=this; 
    }
    
    void Start()
    {   
    }
    public void SetStatus(Sprite now_stage)
    {
        state.sprite = now_stage;
    }
}
