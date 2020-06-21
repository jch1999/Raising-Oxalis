using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenSize : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(480, 640, false);
    }
}
