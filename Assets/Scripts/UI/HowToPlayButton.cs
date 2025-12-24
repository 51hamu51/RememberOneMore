using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;

    [SerializeField] private GameObject asobikata;
    [SerializeField] private GameObject modeExplain;

    void Start()
    {
        PanelClose();
    }

    public void PanelOpen()
    {
        asobikata.SetActive(true);
        modeExplain.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void PanelClose()
    {
        howToPlayPanel.SetActive(false);
    }

    /// <summary>
    /// あそびかた/モード を切り替え
    /// </summary>
    public void ChangeText()
    {
        asobikata.SetActive(!asobikata.active);
        modeExplain.SetActive(!modeExplain.active);
    }
}
