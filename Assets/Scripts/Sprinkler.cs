using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprinkler : MonoBehaviour
{
	public Oxalis oxalis;
    public AudioClip pouring_water;
    AudioSource audioSource;
    //for cool time setting
    private float S_coolTime;
    private float S_itemTime;
    private bool S_usable;
    private bool S_itemActive;
    //Button text
    public Text button_Text;
    // Start is called before the first frame update
    void Awake()
    {
        S_usable = GetBool("S_usable");
        S_coolTime = PlayerPrefs.GetFloat("S_coolTime", 0.0f);
        S_itemTime = PlayerPrefs.GetFloat("S_itemTime", 0.0f);
        S_itemActive = GetBool("S_itmeActive");
        audioSource = GetComponent<AudioSource>();
    }
    void start()
    {
        button_Text.gameObject.SetActive(S_usable);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("S_cooltime", this.S_coolTime);
        if (S_usable == true)
        {
            button_Text.GetComponent<Text>().text = divideMin(S_coolTime) + ":" + divideSec(S_coolTime);
            if (S_coolTime > 0)
            {
                S_coolTime -= Time.deltaTime;
            }
            else if (S_coolTime < 0)
            {
                S_coolTime = 0.0f;
            }
            else
            {
                S_usable = false;
                SetBool("S_usable", S_usable);
                PlayerPrefs.Save();
                button_Text.gameObject.SetActive(S_usable);
            }


        }
        if (S_itemActive == true)
        {
            if (S_itemTime > 0)
            {
                S_itemTime -= Time.deltaTime;
            }
            else if (S_itemTime < 0)
            {
                S_itemTime = 0.0f;
            }
            else
            {
                S_itemActive = false;
                oxalis.growSpeed_Origin();
                SetBool("S_itemActive", S_itemActive);
                PlayerPrefs.Save();
            }
        }
        PlayerPrefs.SetFloat("S_cooltime", this.S_coolTime);
        SetBool("S_usable", S_usable);
        PlayerPrefs.SetFloat("S_itemTime", S_itemTime);
        SetBool("S_itemActive", S_itemActive);
        PlayerPrefs.Save();
    }
    	
    public void buttton_clicked()
    {
    	if(S_usable==false)
    	{
    		S_usable=true;
            SetBool("S_usable", S_usable);
            S_itemActive = true;
            SetBool("S_itemActive", S_itemActive);
            S_coolTime = 18.0f;
            oxalis.growSpeed_Up();
            S_itemTime = 18.0f;
            button_Text.gameObject.SetActive(S_usable);
            Playsound(pouring_water);
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
