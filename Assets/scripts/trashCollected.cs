using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class trashCollected : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = " Trash Collected: " + game.getTrashCollected() + "/12";
    }


    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = " Trash Collected: " + game.getTrashCollected() + "/12";
    }
}
