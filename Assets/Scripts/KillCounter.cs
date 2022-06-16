using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    // This script is for killed enemy's count

    public TextMeshProUGUI killCounterText;

    public static int killCount;

    void Start()
    {
        killCount = 0;
    }

    private void Update()
    {
        killCounterText.text = "" + killCount;
    }


}
