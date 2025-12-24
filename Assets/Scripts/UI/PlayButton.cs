using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    /// <summary>
    /// ボタンが押されたときのSE
    /// </summary>
    [SerializeField] private AudioClip clickSE;
    public void GoMainScene()
    {
        SEManager.Instance.PlayOneTime(clickSE);
        SceneManager.LoadScene("MainScene");
    }
}
