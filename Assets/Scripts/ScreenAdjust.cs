using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdjust : MonoBehaviour
{
    void Start()
    {
        //This line of code makes the camera aspect as follows
        Camera.main.aspect = 1440f / 2960f;
    }


}
