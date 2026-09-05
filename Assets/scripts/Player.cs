using UnityEngine;
using UnityEngine.InputSystem; 

/// <summary>
/// Moves forward/backward and rotates with WASD/Arrow keys.
/// </summary>
public class Player : MonoBehaviour
{
    
    private Vector2 moveInput = Vector2.zero;
    public GameObject onCrashEffect;
    
    //public GameObject withTrashEffect;
    private bool crashed = false;
    public AudioSource audioSource;
    public float volume = 1f;
    public AudioSource audioSourceForWinScreen;
    public float volumeForWinScreen = 1f;
    private static bool hasTrash = false;
    public static bool timeStopped = false;
    private bool win = false;


    
    [Tooltip("Forward/back speed (units/sec).")]
    public float speed = 5.0f;

    [Tooltip("Turn speed (degrees/sec).")]
    public float rotationSpeed = 120.0f;

    private Rigidbody rb; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogWarning("PlayerController needs a Rigidbody.");
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
        audioSourceForWinScreen.playOnAwake = false;
        audioSourceForWinScreen.volume = volumeForWinScreen;
    }

    public static bool getTrash()
    {
        return hasTrash;
    }
    
    public static void removeTrash()
    {
        hasTrash = false;
    }

    public static void giveTrash()
    {
        hasTrash = true;
    }
    
    private void Update()
    {
        if (!crashed)
        {
            // Move in facing direction 
            Vector3 movement = transform.forward * moveInput.y * speed / 100 * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }
        else
        {
            moveInput.y = 0;
        }

        if (!timeStopped)
        {
            game.updateTime();
        }

        if (win)
        {
            moveInput.y = 0;
        }
        
        if (game.getTrashCollected() == 12)
        {
            win = true;
            audioSourceForWinScreen.Play();
            WinScreen.showWinScreen();
            game.setTrashCollected(0);
        }
        
    }

    public static void pauseTime()
    {
        timeStopped = true;
    }
    
    public static void unPauseTime()
    {
        timeStopped = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("crash") && !crashed)
        {
            Vector3 distance = transform.localPosition * 0.99f;
            Instantiate(onCrashEffect, distance, transform.localRotation);
            crashed = true;
            audioSource.Play();
            loseScreen.showLoseScreenButton();
        }
    }
    
    private void  OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("crash") && !crashed)
        {
            Vector3 distance = transform.localPosition * 0.99f;
            Instantiate(onCrashEffect, distance, transform.localRotation);
            crashed = true;
            audioSource.Play();
            loseScreen.showLoseScreenButton();
        }
    }

    private void FixedUpdate() 
    {
        moveInput.x = 0f;

        // Forward/backward
        if ((Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) && !crashed && !win)   moveInput.y += 1f;
        if ((Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) && moveInput.y != 0 && !crashed && !win) moveInput.y -= 1f;

        // Left/right (rotation)
        if ((Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) && !crashed && !win) moveInput.x = -1f;
        if ((Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) && !crashed && !win) moveInput.x = 1f;

        

        // Y-axis rotation (invert when going backwards)
        float turnDirection = moveInput.x;
        if (moveInput.y < 0)
            turnDirection = -turnDirection;

        float turn = turnDirection * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}