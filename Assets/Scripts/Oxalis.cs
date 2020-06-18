using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxalis : MonoBehaviour
{
	public AudioClip grow_sound;
	AudioSource audioSource;
	private float save_time=0;//for auto save	
							  //for manage Exp
	private float grow_Speed;
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
		grow_Speed = PlayerPrefs.GetFloat("grow_Speed", 10.0f);
		Max_Exp=max[now_stage];
		audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void  FixedUpdate()
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
		changeState();
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
		Playsound(grow_sound);
	}
	void changeState()
	{
		//update left top UI Bar
		UIControl.instance.SetValue(getExpPercentage());
		SliderControl.SC.setValue(getExpPercentage());
	}
	public void Playsound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
