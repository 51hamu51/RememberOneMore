using UnityEngine;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject asobikata;
    [SerializeField] private GameObject modeExplain;

    [Header("パネルのアニメーション用")]
    [SerializeField] private float animDuration;
    [SerializeField] private float moveY;
    [SerializeField] private RectTransform panelRect;
    [SerializeField] private CanvasGroup canvasGroup;
    private Vector2 defaultPos;


    void Start()
    {
        defaultPos = panelRect.anchoredPosition;
        PanelCloseImmediate();
    }

    /// <summary>
    /// パネルを開く(アニメーション)
    /// </summary>
    public void PanelOpen()
    {
        asobikata.SetActive(true);
        modeExplain.SetActive(false);
        howToPlayPanel.SetActive(true);

        // 初期状態
        panelRect.anchoredPosition = defaultPos + Vector2.up * moveY;
        canvasGroup.alpha = 0f;

        // アニメーション
        panelRect.DOAnchorPos(defaultPos, animDuration).SetEase(Ease.OutCubic);
        canvasGroup.DOFade(1f, animDuration);
    }

    /// <summary>
    /// パネルを閉じる(アニメーション)
    /// </summary>
    public void PanelClose()
    {
        canvasGroup.DOFade(0f, animDuration);
        panelRect
            .DOAnchorPos(defaultPos + Vector2.up * moveY, animDuration)
            .SetEase(Ease.InCubic)
            .OnComplete(() =>
            {
                howToPlayPanel.SetActive(false);
            });
    }

    /// <summary>
    /// パネルを素早く閉じる
    /// </summary>
    private void PanelCloseImmediate()
    {
        howToPlayPanel.SetActive(false);
        canvasGroup.alpha = 0f;
        panelRect.anchoredPosition = defaultPos;
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
