using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// ノード識別用
    /// </summary>
    public int nodeId;

    [Header("カラー（HTMLカラーコード・#つき）")]
    [SerializeField] private string normalColor;
    [SerializeField] private string litColor;

    private Image nodeImage;

    void Start()
    {
        nodeImage = GetComponent<Image>();
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
            return;

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
}
