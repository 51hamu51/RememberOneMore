using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    /// <summary>
    /// ボタンが押されたときのSE
    /// </summary>
    [SerializeField] private AudioClip clickSE;
    public void StartChallengeMode()
    {
        SEManager.Instance.PlayOneTime(clickSE);
        LevelManager.Instance.ChangeMode(LevelManager.Mode.CHALLENGE);
        SceneManager.LoadScene("MainScene");
    }

    public void StartEndlessMode()
    {
        SEManager.Instance.PlayOneTime(clickSE);
        LevelManager.Instance.ChangeMode(LevelManager.Mode.ENDLESS);
        SceneManager.LoadScene("MainScene");
    }
}
