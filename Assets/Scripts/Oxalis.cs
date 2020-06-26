using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Oxalis : MonoBehaviour
{
	//시간의 변환 표현
	public Image day, night;
	private float time;
	//레벨업 마다 이미지 변경을 위한 컴포넌트 지정
	Image now;
	public Sprite LV1, LV2, LV3, LV4, LV5;
	//sound
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
		now = gameObject.GetComponent<Image>();
		now_stage =PlayerPrefs.GetInt("now_stage",0);
		now_Exp=PlayerPrefs.GetFloat("now_Exp",0.0f);
		grow_Speed = 10.0f;//저장오류로 인해 임시변경
		//grow_Speed = PlayerPrefs.GetFloat("grow_Speed", 10.0f);
		time = PlayerPrefs.GetFloat("time", 0.0f);
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
		time += Time.deltaTime;
		//자동저장
		if(save_time>4.0f)
		{
			PlayerPrefs.SetInt("now_stage",this.now_stage);
			PlayerPrefs.SetFloat("now_Exp",this.now_Exp);
			//PlayerPrefs.SetFloat("grow_Speed", grow_Speed);
			PlayerPrefs.SetFloat("time", time);
			PlayerPrefs.Save();
			save_time=0.0f;
		}
		changeState();//경험치바 상승
		//성장단계 변화
		if (now_Exp>=Max_Exp)
		{
			if(now_stage<4)
				Oxalis_Grow();
			else
            {
				grow_Speed = 0.0f;
				now_Exp = Max_Exp;
            }
		}
		//성장 이미지 지정
		switch (now_stage)
		{
			case 0:
				now.sprite = LV1;
				UIControl.instance.SetStatus(LV1);
				break;
			case 1:
				now.sprite = LV2;
				UIControl.instance.SetStatus(LV2);
				break;
			case 2:
				now.sprite = LV3;
				UIControl.instance.SetStatus(LV3);
				break;
			case 3:
				now.sprite = LV4;
				UIControl.instance.SetStatus(LV4);
				break;
			case 4:
				now.sprite = LV5;
				UIControl.instance.SetStatus(LV5);
				break;
		}
		//배경 이미지 변경 - 시간변화
		if (time < 180.0f)
		{
			day.gameObject.SetActive(true);
			night.gameObject.SetActive(false);
		}
		else if (time < 360.0f && time > 180.0f)
		{
			day.gameObject.SetActive(false);
			night.gameObject.SetActive(true);
		}
		else
			time = 0.0f;
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
		SliderControl.SC.setValue(getExpPercentage());
	}
	public void Playsound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
