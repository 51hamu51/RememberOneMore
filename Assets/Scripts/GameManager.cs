using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
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

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// ゲームを初期化
    /// </summary>
    public void ResetGame()
    {
        nowPhase = Phase.READY;
        ScoreManager.Instance.ResetScore();
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
