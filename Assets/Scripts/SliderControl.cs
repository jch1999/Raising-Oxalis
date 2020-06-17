using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public static SliderControl SC { get; private set; }
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        SC = this;
    }

    // Update is called once per frame
    public void setValue(float amount)
    {
        slider.value = Mathf.MoveTowards(slider.value, amount, 0.01f);
    }
}
