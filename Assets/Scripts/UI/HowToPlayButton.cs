using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    void Start()
    {
        PanelClose();
    }

    public void PanelOpen()
    {
        howToPlayPanel.SetActive(true);
    }

    public void PanelClose()
    {
        howToPlayPanel.SetActive(false);
    }
}
