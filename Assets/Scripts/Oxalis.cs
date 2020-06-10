using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxalis : MonoBehaviour
{
<<<<<<< HEAD
    private float save_time = 0;//for auto save

    private float SpeedTime;
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
=======
	private float save_time=0;//for auto save
	//for manage Exp
	private float grow_Speed=3.0f;
	private float[] max=new float[5];//the max_exp of each stage
	private int now_stage;
	float now_Exp;
	float Max_Exp;
    // Awake is called when the program was started
    void Awake()
    {
        max[0]=500.0f;
		max[1]=1200.0f;
		max[2]=2400.0f;
		max[3]=3600.0f;
		max[4]=5000.0f;
		now_stage=PlayerPrefs.GetInt("now_stage",0);
		now_Exp=PlayerPrefs.GetFloat("now_Exp",0.0f);
		Max_Exp=max[now_stage];
>>>>>>> 06633eaa9cfdf659d728417686fb7676881b7376
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
    void fixedUpdate()
    {
        now_Exp += Time.deltaTime * grow_Speed;
        save_time += Time.deltaTime;
        if (save_time > 4.0f)
        {
            PlayerPrefs.SetInt("now_stage",this.now_stage);
            PlayerPrefs.SetFloat("now_Exp",this.now_Exp);
            PlayerPrefs.Save();
            save_time = 0.0f;
        }
        //update left top UI Bar
        UIControl.instance.SetValue(now_Exp / Max_Exp);
        if (now_Exp >= Max_Exp)
        {
            oxalis_Grow();
        }

        if (SpeedTime < 0)
        {
            SpeedTime -= Time.deltaTime;
        }
    }

    public float getExpPercentage()
    {
        return now_Exp / Max_Exp;
    }
    //this function will operate when Sprinkler or Nutrient is clicked
    public void growSpeed_Up()
    {
        this.grow_Speed = this.grow_Speed * 2;
    }
    //this functino will operate when the SpeedUp time end
    public void growSpeed_Origin()
    {
        this.grow_Speed = this.grow_Speed / 2;
    }
    //this fuction will change image when it graw up
    void oxalis_Grow()
    {
        now_stage += 1;
        Max_Exp = max[now_stage];
        now_Exp = 0;
    }
=======
	void  fixedUpdate()
	{
		now_Exp+=Time.deltaTime*grow_Speed;
		save_time+=Time.deltaTime;
		if(save_time>4.0f)
		{
			PlayerPrefs.SetInt("now_stage",this.now_stage);
			PlayerPrefs.SetFloat("now_Exp",this.now_Exp);
			PlayerPrefs.Save();
			save_time=0.0f;
		}
		//update left top UI Bar
		UIControl.instance.SetValue(getExpPercentage());
		if(now_Exp>=Max_Exp)
		{
			Oxalis_Grow();
		}
	}
	float getExpPercentage()
	{
		return now_Exp/Max_Exp;
	}
	//this functionwill will operate when Sprinkler ir Nutrient is clicked
	public void growSpeed_Up()
	{
		this.grow_Speed=this.grow_Speed*2;
	}
	//this function will operate when the each item's effort is ended
	public void growSpeed_Origin()
	{
		this.grow_Speed=this.grow_Speed/2;
	}
	//this functionwill change image when Oxalis grow up
	void Oxalis_Grow()
	{
		now_stage+=1;
		Max_Exp=max[now_stage];
		now_Exp=0;
	}
>>>>>>> 06633eaa9cfdf659d728417686fb7676881b7376
}
