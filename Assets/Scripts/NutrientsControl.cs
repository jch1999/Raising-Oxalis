using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
public class NutrientsControl : MonoBehaviour
{
    //for cool time setting
    private float N_coolTime;
    private bool N_usable;
    //Button text
    public Text button_Text;
    // Start is called before the first frame update
    void Start()
    {
        N_usable = GetBool("N_usable");
        button_Text.gameObject.SetActive(N_usable);
        N_coolTime = PlayerPrefs.GetFloat("N_coolTime",0.0f);
=======

public class Nutrients : MonoBehaviour
{
	//for cool time setting
	private float N_coolTime;
	private bool N_usable;
	//Button text
	public Text button_Text;
    // Start is called before the first frame update
    void Start()
    {
		N_usable =GetBool("N_usable");
		button_Text.gameObject.SetActive(N_usable);
		N_coolTime=PlayerPrefs.GetFloat("N_coolTime",0.0f);
        
>>>>>>> 06633eaa9cfdf659d728417686fb7676881b7376
    }

    // Update is called once per frame
    void Update()
    {
    }

    void fixedUpdate()
    {
        PlayerPrefs.SetFloat("N_coolTime",this.N_coolTime);
        SetBool("N_usable",N_usable);
        if(N_usable==true)
        {
            button_Text.text = N_coolTime.ToString();
            if (N_coolTime > 0)
            {
                N_coolTime -= Time.deltaTime;
            }
            else if (N_coolTime < 0)
            {
                N_coolTime = 0.0f;
            }else if (N_coolTime == 0)
            {
                N_usable = false;
            }
        }
    }

    public void button_clicked()
    {
        if (N_usable == false)
        {
            N_usable = true; 
            button_Text.gameObject.SetActive(N_usable); 
        }
    }
    //for save and loat the bool date
    public void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    public bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key,0);
        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
	void fixedUpdate()
	{
		PlayerPrefs.SetFloat("N_cooltime",this.N_coolTime);
		SetBool("N_usable",N_usable);
		if(N_usable==true)
		{
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
}
