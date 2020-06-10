using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD

public class StartGame : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
=======
public class StartGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
>>>>>>> 06633eaa9cfdf659d728417686fb7676881b7376
            SceneManager.LoadScene("Raising Oxalis");
        }
    }
}
