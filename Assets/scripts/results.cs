using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class results : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "                 Time: " + game.getTime() + "\n" +
                                               "                 Rank: " + getRank();
    }

    private String getRank()
    {
        int t = game.getTime();
        if (t <= 180)
        {
            return "S";
        }else if (t <= 240)
        {
            return "A";
        }else if (t <= 300)
        {
            return "B";
        }else if (t <= 360)
        {
            return "C";
        }else if (t <= 420)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}
