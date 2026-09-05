using UnityEngine;

public class loseScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private static GameObject myCanvas;

    void Start()
    {
        myCanvas = GetComponentInChildren<Canvas>().gameObject;
        myCanvas.SetActive(false);
    }

    // Update is called once per frame
    public static void showLoseScreenButton()
    {
          Player.pauseTime();
          myCanvas.SetActive(true);
    }
}
