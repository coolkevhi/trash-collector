using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private static GameObject myCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCanvas = GetComponentInChildren<Canvas>().gameObject;
        myCanvas.SetActive(true);
    }

    public static void leaveMainMenu()
    {
        myCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
