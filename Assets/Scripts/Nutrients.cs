using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nutrients : MonoBehaviour
{
	public Oxalis oxalis;
	public AudioClip nutrient_sound;
	AudioSource audioSource;
	//for cool time setting
	private float N_coolTime;
	private bool N_usable;
	private float N_itemTime;
	private bool N_itemActive;
	//Button text
	public Text button_Text;
    // Start is called before the first frame update
    void Awake()
    {
		N_usable =GetBool("N_usable");
		N_coolTime = PlayerPrefs.GetFloat("N_coolTime", 0.0f);
		N_itemTime = PlayerPrefs.GetFloat("N_itemTime", 0.0f);
		N_itemActive = GetBool("N_itmeActive");
		audioSource = GetComponent<AudioSource>();
	}
	void start()
	{
		button_Text.gameObject.SetActive(N_usable);
	}
	// Update is called once per frame
	void Update()
	{
	}
	void FixedUpdate()
	{
		button_Text.GetComponent<Text>().text = divideMin(N_coolTime) + ":" + divideSec(N_coolTime);
		if (N_usable==true)
		{
			if (N_coolTime > 0)
			{
				N_coolTime -= Time.deltaTime;
			}
			else if (N_coolTime < 0)
			{
				N_coolTime = 0.0f;
			}
			else
			{
				N_usable = false;
				SetBool("N_usable",N_usable);
				button_Text.gameObject.SetActive(N_usable);
			}
		}
		if(N_itemActive==true)
        {
			if (N_itemTime > 0)
			{
				N_itemTime -= Time.deltaTime;
			}
			else if (N_itemTime < 0)
			{
				N_itemTime = 0.0f;
			}
			else
			{
				N_itemActive = false;
				SetBool("N_itemActive", N_itemActive);
				oxalis.growSpeed_Origin();
			}
		}
		PlayerPrefs.SetFloat("N_cooltime", this.N_coolTime);
		SetBool("N_usable", N_usable);
		PlayerPrefs.SetFloat("N_itemTime", N_itemTime);
		SetBool("N_itemActive", N_itemActive);
		PlayerPrefs.Save();
	}
	
	public void buttton_clicked()
	{
		if(N_usable==false)
		{
			N_usable=true;
			SetBool("N_usable",N_usable);
			N_itemActive = true;
			SetBool("N_itemActive", N_itemActive);
			N_coolTime = 6.0f;
			oxalis.growSpeed_Up();
			N_itemTime = 3.0f;
			button_Text.gameObject.SetActive(N_usable);
			Playsound(nutrient_sound);
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
	public void Playsound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}

