using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
   //when the eixt_button is clicked
   public void Exit()
   {
      PlayerPrefs.Save();
      Application.Quit();
   }
}
