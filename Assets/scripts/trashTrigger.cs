using UnityEngine;

public class trashTrigger : MonoBehaviour
{
    
    public AudioSource audioSource;
    public float volume = 1f;
    private Renderer rend;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.playOnAwake = false;
        audioSource.volume = volume; 
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Player") && !Player.getTrash())
        {
            audioSource.Play();
            Player.giveTrash();
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
