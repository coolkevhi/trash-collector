using UnityEngine;
using UnityEngine.SceneManagement;
public class playAgain : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        game.reset();
    }
}
