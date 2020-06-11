using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrients : MonoBehaviour
{
	public Oxalis oxalis;
	//for cool time setting
	private float N_coolTime;
	private bool N_usable;
	//Button text
	public Text button_Text;
    // Start is called before the first frame update
    void Awake()
    {
		N_usable =GetBool("N_usable");
		button_Text.gameObject.SetActive(N_usable);
		N_coolTime=PlayerPrefs.GetFloat("N_coolTime",0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
       if (N_usable == true)
       {
        	button_Text.GetComponent<Text>().text=divideMin(N_coolTime)+":"+divideSec(N_coolTime); 
       } 
    }
	void FixedUpdate()
	{
		PlayerPrefs.SetFloat("N_cooltime",this.N_coolTime);
		SetBool("N_usable",N_usable);
		if(N_usable==true)
		{
			button_Text.GetComponent<Text>().text=divideMin(N_coolTime)+":"+divideSec(N_coolTime);
			if(N_coolTime>0)
			{
				N_coolTime-=Time.deltaTime;
			}
			else if (N_coolTime<0)
			{
				N_coolTime=0.0f;
			}
			else
				N_usable=false;
		}
	}
	
	public void buttton_clicked()
	{
		if(N_usable==false)
		{
			N_usable=true;
			button_Text.gameObject.SetActive(N_usable);
			N_coolTime=3600.0f;
		}
	}
	//for save and loaf the bool date
	public void SetBool(string key, bool state)
	{
		PlayerPrefs.SetInt(key,state?1:0);
	}
	public bool GetBool(string key)
	{
		int value=PlayerPrefs.GetInt(key,0);
		if(value==1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	int divideMin(float coolTime)
    {
    	return  (int)coolTime/60;
    }
    int divideSec(float coolTime)
    {	
    	return (int)coolTime%60;
    }
}

