using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleRippleCircle : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float maxScale;
    [SerializeField] private Image effectImage;
    [SerializeField] private RectTransform effectRect;

    public void Play(Color color)
    {
        effectRect.localScale = Vector3.zero;
        effectImage.color = new Color(color.r, color.g, color.b, 0.1f);

        Sequence seq = DOTween.Sequence();
        seq.Append(effectRect.DOScale(maxScale, duration).SetEase(Ease.OutCubic));
        seq.Join(effectImage.DOFade(0f, duration));
        seq.OnComplete(() => Destroy(gameObject));
    }
}
