using UnityEngine;

public class Dumpster : MonoBehaviour
{
    [SerializeField] 
    private bool open = true;
    
    public GameObject gaveTrashEffect;
    public AudioSource audioSource;
    public float volume = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && open && Player.getTrash())
        {
            Vector3 distance = transform.position * 1f;
            Instantiate(gaveTrashEffect, distance, transform.rotation);
            open = false;
            audioSource.Play();
            Player.removeTrash();
            game.incTrashCollected();
            
            
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.localRotation = Quaternion.Euler(-150.98f, 0f, 0f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(-89.98f, 0f, 0f);
        }
    }
}
