using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    private Renderer rend;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.getTrash())
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }
    }
}
