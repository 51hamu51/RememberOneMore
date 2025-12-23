using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// 現在のスコア
    /// </summary>
    [SerializeField] private int nowScore;

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// スコアをリセット
    /// </summary>
    public void Reset()
    {
        SetScore(0);
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
}
