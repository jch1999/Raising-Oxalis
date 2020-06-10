using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
<<<<<<< HEAD
    public static UIControl instance { get; private set; }
    public Image mask;
    private float originalSize;
    private Oxalis oxalis;
    
    void Awake() 
    {
        instance=this; 
    }
    
    void Start()
    {
        originalSize=mask.rectTransform.rect.width;    
    }

    public void SetValue(float value) 
=======
	public static UIControl instance{get;private set;}
	public Image mask;
	private float originalSize;
	
    // Awake is called when the program started
    void Awake()
    {
        instance=this;
    }
	//Start is called before the first frame Update
	void Start()
	{
		originalSize=mask.rectTransform.rect.width;
	}
	public void SetValue(float value)
	{
	mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize*value);
	}
    // Update is called once per frame
    void Update()
>>>>>>> 06633eaa9cfdf659d728417686fb7676881b7376
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize*value); 
    }
}
