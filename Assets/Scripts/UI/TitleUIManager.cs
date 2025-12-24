using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;

    [SerializeField] private GameObject asobikata;
    [SerializeField] private GameObject modeExplain;

    [SerializeField] private GameObject menuButtons;

    void Start()
    {
        PanelClose();
    }

    public void PanelOpen()
    {
        menuButtons.SetActive(false);
        asobikata.SetActive(true);
        modeExplain.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void PanelClose()
    {
        menuButtons.SetActive(true);
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
