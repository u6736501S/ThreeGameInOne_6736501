using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayDriving() { SceneManager.LoadScene("DrivingGame"); }
    public void PlayFlying()  { SceneManager.LoadScene("FlyingGame"); }
    public void PlaySumo()    { SceneManager.LoadScene("SumoBall"); }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Application.Quit() does nothing in the editor
#else
        Application.Quit();
#endif
    }
}