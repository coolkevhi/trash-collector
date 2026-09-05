using UnityEngine;

public class AboutButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void launchAbout()
    {
        MainMenu.leaveMainMenu();
        AboutPage.showAbout();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
