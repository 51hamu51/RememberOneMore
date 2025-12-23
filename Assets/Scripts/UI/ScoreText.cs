using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
    }

    void Update()
    {
        scoreText.text = "スコア：" + ScoreManager.Instance.GetScore();
    }
}
