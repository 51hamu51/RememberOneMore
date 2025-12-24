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

    /// <summary>
    /// タップされたときの音
    /// </summary>
    [SerializeField] private AudioClip tapSE;

    [Header("カラー（HTMLカラーコード・#つき）")]
    [SerializeField] private string normalColor;
    [SerializeField] private string litColor;

    /// <summary>
    /// デフォルトの大きさを取得しておく
    /// </summary>
    private Vector3 defaultScale;

    private Image nodeImage;
    private Tween tapTween;


    [Header("タップエフェクト(円)用")]
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private float maxScale = 1.6f;
    [SerializeField] private Image effectImage;
    [SerializeField] private RectTransform effectRect;

    private Tween colorTween;

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
        SEManager.Instance.PlayOneTime(tapSE);
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
        Flash();
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

        nodeImage.color = GetColorCode(htmlColor);

    }

    /// <summary>
    /// タップされたときの反応
    /// </summary>
    /// <returns></returns>
    private void PlayTapScaleEffect()
    {

        CircleEffectPlay(GetColorCode(litColor));


        SEManager.Instance.PlayOneTime(tapSE);
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

    /// <summary>
    /// 円形エフェクト再生
    /// </summary>
    /// <param name="color"></param>
    public void CircleEffectPlay(Color color)
    {
        effectRect.DOKill();
        effectImage.DOKill();

        effectImage.color = new Color(color.r, color.g, color.b, 0.35f);
        effectRect.localScale = Vector3.zero;
        effectImage.color = new Color(color.r, color.g, color.b, 0.6f);

        effectRect.DOScale(maxScale, duration)
            .SetEase(Ease.OutCubic);

        effectImage.DOFade(0f, duration)
            .SetEase(Ease.OutCubic);
    }

    /// <summary>
    /// タップ時に一瞬光って戻る
    /// </summary>
    public void Flash()
    {
        colorTween?.Kill();

        // 即座に点灯
        SetColor(litColor);

        // 少し待ってから、ゆっくり戻す
        colorTween = nodeImage
            .DOColor(GetColorCode(normalColor), 0.25f)
            .SetEase(Ease.OutSine);
    }

    /// <summary>
    /// htmlカラーコードから、Unity用のカラーコードを取得
    /// </summary>
    /// <param name="htmlColor"></param>
    /// <returns></returns>
    private Color GetColorCode(string htmlColor)
    {
        ColorUtility.TryParseHtmlString(htmlColor, out Color color);
        return color;
    }

}
