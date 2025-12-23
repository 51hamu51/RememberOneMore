using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Phase
    {
        READY,//準備
        SHINE,//お手本が光る
        TAP,//ノードにタッチ・正誤判定
        RESULT,//結果
    }

    /// <summary>
    /// 現在のフェーズ
    /// </summary>
    [SerializeField] private Phase nowPhase;

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// 現在のフェーズを返す
    /// </summary>
    /// <returns></returns>
    public Phase NowPhase()
    {
        return nowPhase;
    }
}
