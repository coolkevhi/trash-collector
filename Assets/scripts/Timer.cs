using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    private static TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.enabled = true;
        GetComponent<TextMeshProUGUI>().text = "" + game.getTime();
    }

    public static void finish()
    {
        text.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "" + game.getTime();
    }
}
