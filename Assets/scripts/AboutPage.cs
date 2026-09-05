using UnityEngine;

public class AboutPage : MonoBehaviour
{
    private static GameObject myCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCanvas = GetComponentInChildren<Canvas>().gameObject;
        myCanvas.SetActive(false);
    }

    public static void showAbout()
    {
        myCanvas.SetActive(true);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
