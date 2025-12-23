using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject readyText;
    [SerializeField] private GameObject correctText;
    [SerializeField] private GameObject missText;
    [SerializeField] private GameObject retryButton;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// 画面をタップしてねのテキストを表示
    /// </summary>
    public void ReadyTextOn()
    {
        readyText.SetActive(true);
    }

    /// <summary>
    /// 画面をタップしてねのテキストを消去
    /// </summary>
    public void ReadyTextOff()
    {
        readyText.SetActive(false);
    }

    /// <summary>
    /// 成功のテキストを表示
    /// </summary>
    public void CorrectTextOn()
    {
        correctText.SetActive(true);
    }

    /// <summary>
    /// 成功のテキストを消去
    /// </summary>
    public void CorrectTextOff()
    {
        correctText.SetActive(false);
    }

    /// <summary>
    /// 失敗のテキストを表示
    /// </summary>
    public void MissTextOn()
    {
        missText.SetActive(true);
        retryButton.SetActive(true);
    }

    /// <summary>
    /// 失敗のテキストを消去
    /// </summary>
    public void MissTextOff()
    {
        missText.SetActive(false);
        retryButton.SetActive(false);
    }

}
