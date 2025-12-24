using UnityEngine;
using DG.Tweening;

public class TextShaker : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float strength;

    private RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    /// <summary>
    /// テキストを揺らす
    /// </summary>
    public void Shake()
    {
        rect.DOKill();

        rect.DOShakeAnchorPos(
            duration,
            strength,
            vibrato: 6,
            randomness: 20f,
            snapping: false,
            fadeOut: true
        );
    }
}
