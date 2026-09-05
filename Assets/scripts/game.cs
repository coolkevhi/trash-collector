using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class game : MonoBehaviour
{
    private static int trashCollected = 0;

    private static int time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public static void incTrashCollected()
    {
        trashCollected++;
    }
    
    public static void reset()
    {
        trashCollected =0;
        time = 0;
        Player.removeTrash();
        Player.unPauseTime();
    }

    public static int getTrashCollected()
    {
        return trashCollected;
    }

    public static void setTrashCollected(int collected)
    {
        trashCollected = collected;
    }

    public static int getTime()
    {
        return time;
    }

    // Update is called once per frame
    public static void updateTime()
    {
        time = (int)Time.timeSinceLevelLoad;
    }
}
