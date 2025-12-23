using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    /// <summary>
    /// 現在のスコア
    /// </summary>
    [SerializeField] private int nowScore;

    /// <summary>
    /// 正解一回当たりの増加スコア(倍率なしの場合)
    /// </summary>
    [SerializeField] private int basicScore;

    /// <summary>
    /// 現在の連続正解数
    /// </summary>
    public int combo;

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
    /// スコアをリセット
    /// </summary>
    public void ResetScore()
    {
        SetScore(0);
        combo = 0;
    }

    /// <summary>
    ///スコアをxだけ加算
    /// </summary>
    /// <param name="x"></param>
    public void AddScore(int x)
    {
        nowScore += x;
    }

    /// <summary>
    ///スコアをxだけ減算
    /// </summary>
    /// <param name="x"></param>
    public void SubScore(int x)
    {
        nowScore -= x;
    }

    /// <summary>
    /// スコアをxにする
    /// </summary>
    /// <param name="x"></param>
    public void SetScore(int x)
    {
        nowScore = x;
    }

    /// <summary>
    ///スコアを取得
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return nowScore;
    }

    /// <summary>
    /// 正解したときの処理
    /// </summary>
    public void Correct()
    {
        combo++;
        int increaseScore = Mathf.RoundToInt(basicScore * (1 + (combo - 1) * 0.15f));
        AddScore(increaseScore);
    }

    /// <summary>
    /// 現在のコンボ数を取得
    /// </summary>
    /// <returns></returns>
    public int GetCombo()
    {
        return combo;
    }
}
