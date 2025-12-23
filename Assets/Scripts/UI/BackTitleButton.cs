using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitleButton : MonoBehaviour
{
    public void BackTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
