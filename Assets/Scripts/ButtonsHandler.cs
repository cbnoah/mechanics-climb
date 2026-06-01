using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour
{
    public void SwitchToPlayScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LeaveTheGame()
    {
        Application.Quit();
    }
}
