using UnityEngine;

public class WinScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private static GameObject myCanvas;

    void Start()
    {
        myCanvas = GetComponentInChildren<Canvas>().gameObject;
        myCanvas.SetActive(false);
    }

    // Update is called once per frame
    public static void showWinScreen()
    {
          myCanvas.SetActive(true);
          Timer.finish();
          Player.pauseTime();
    }
}
