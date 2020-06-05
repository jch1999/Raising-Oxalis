using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxalis : MonoBehaviour
{
    private float save_time = 0;
    //for manage Exp
    private float grow_Speed = 3.0f;
    private float[] max=new float[5];// the max_exp of each stage
    private int now_stage;
    float now_Exp;
    float Max_Exp;
    // Start is called before the first frame update
    void Awake()
    {
        max[0] = 500.0f;
        max[1] = 1200.0f;
        max[2] = 2400.0f;
        max[3] = 3600.0f;
        max[4] = 5000.0f;
        now_stage = PlayerPrefs.GetInt("now_stage",0);
        now_Exp = PlayerPrefs.GetFloat("now_Exp",0);
        Max_Exp = max[now_stage];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fixedUpdate()
    {
        now_Exp += Time.deltaTime * grow_Speed;
        save_time += Time.deltaTime;
        if (save_time > 4.0f)
        {
            PlayerPrefs.SetInt("now_stage",this.now_stage);
            PlayerPrefs.SetFloat("now_Exp",this.now_Exp);
        }
        //update left top UI Bar
        UIControl.instance.SetValue(now_Exp / Max_Exp);
    }

    public float getExpPercentage()
    {
        return now_Exp / Max_Exp;
    }

    public void growSpeed_Up()
    {
        this.grow_Speed = this.grow_Speed * 2;
    }

    public void growSpeed_Origin()
    {
        this.grow_Speed = this.grow_Speed / 2;
    }
}
