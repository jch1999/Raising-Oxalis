using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public static SliderControl SC { get; private set; }
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void setValue(float vlaue)
    {
        slider.value = Mathf.MoveTowards(slider.value, vlaue, 0.01f);
    }
}
