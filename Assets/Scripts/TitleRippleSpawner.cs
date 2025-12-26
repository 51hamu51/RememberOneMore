using UnityEngine;
using System.Collections;

public class TitleRippleSpawner : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [Header("Prefab")]
    [SerializeField] private TitleRippleCircle ripplePrefab;

    [Header("再生エリア")]
    [SerializeField] private RectTransform playArea;

    [Header("ランダム間隔")]
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnRippleAtScreenPosition(Input.mousePosition);
        }
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnRandomRipple();
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }

    /// <summary>
    /// ランダムな位置に生成
    /// </summary>
    void SpawnRandomRipple()
    {
        Vector2 randomPos = new Vector2(
            Random.Range(-playArea.rect.width / 2f, playArea.rect.width / 2f),
            Random.Range(-playArea.rect.height / 2f, playArea.rect.height / 2f)
        );

        SpawnRipple(randomPos);
    }

    /// <summary>
    /// タップ位置に生成
    /// </summary>
    /// <param name="screenPos"></param>
    void SpawnRippleAtScreenPosition(Vector2 screenPos)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            playArea,
            screenPos,
            canvas.worldCamera,
            out Vector2 localPos
        );

        SpawnRipple(localPos);
    }

    /// <summary>
    /// 共通処理(実際に生成する部分)
    /// </summary>
    /// <param name="anchoredPos"></param>
    void SpawnRipple(Vector2 anchoredPos)
    {
        TitleRippleCircle ripple = Instantiate(ripplePrefab, playArea);
        ripple.GetComponent<RectTransform>().anchoredPosition = anchoredPos;

        Color color = Color.HSVToRGB(
            Random.value,
            0.4f,
            1f
        );

        ripple.Play(color);
    }
}
