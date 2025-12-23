using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void GoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
