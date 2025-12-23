using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Node : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// ノード識別用
    /// </summary>
    public int nodeId;

    [Header("カラー（HTMLカラーコード・#つき）")]
    [SerializeField] private string normalColor;
    [SerializeField] private string litColor;

    /// <summary>
    /// デフォルトの大きさを取得しておく
    /// </summary>
    private Vector3 defaultScale;

    private Image nodeImage;
    private Tween tapTween;

    void Start()
    {
        nodeImage = GetComponent<Image>();
        defaultScale = transform.localScale;
        SetColor(normalColor);
    }
    void Update()
    {

    }

    /// <summary>
    /// 光る
    /// </summary>
    public void Shine()
    {
        SetColor(litColor);
    }

    /// <summary>
    /// 元に戻す
    /// </summary>
    public void ResetColor()
    {
        SetColor(normalColor);
    }

    /// <summary>
    /// タップ検知
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        // TAPフェーズ以外は無視
        if (GameManager.Instance.NowPhase() != GameManager.Phase.TAP)
        {
            return;
        }
        PlayTapScaleEffect();
        NodeManager.Instance.OnNodeTapped(nodeId);
    }

    /// <summary>
    /// カラーコードで指定された色に変更
    /// </summary>
    /// <param name="htmlColor"></param>
    private void SetColor(string htmlColor)
    {
        if (nodeImage == null) return;

        if (ColorUtility.TryParseHtmlString(htmlColor, out Color color))
        {
            nodeImage.color = color;
        }
        else
        {
            Debug.LogWarning($"無効なカラーコード: {htmlColor}");
        }
    }

    /// <summary>
    /// タップされたときの反応
    /// </summary>
    /// <returns></returns>
    private void PlayTapScaleEffect()
    {
        tapTween?.Kill();

        transform.localScale = defaultScale;

        tapTween = transform
            .DOScale(defaultScale * NodeManager.Instance.tapScale, NodeManager.Instance.tapDuration * 0.5f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                transform
                    .DOScale(defaultScale, NodeManager.Instance.tapDuration * 0.5f)
                    .SetEase(Ease.InBack);
            });
    }

}
