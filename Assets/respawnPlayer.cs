using UnityEngine;
using UnityEngine.SceneManagement;

public class restartPlayer : MonoBehaviour
{
    public void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}