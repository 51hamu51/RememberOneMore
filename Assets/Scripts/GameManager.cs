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

    /// <summary>
    /// 1ターンに光るノードの数
    /// </summary>
    public int ShineNum;

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
        ResetGame();
    }

    void Update()
    {
        switch (nowPhase)
        {
            case Phase.READY:
                if (Input.GetMouseButtonDown(0))
                {
                    ReadyPhase();
                }
                break;

            case Phase.SHINE:
                break;

            case Phase.TAP:
                break;

            case Phase.RESULT:
                break;
        }
    }

    /// <summary>
    /// 準備フェーズ
    /// </summary>
    private void ReadyPhase()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangePhase(Phase.SHINE);
            ShinePhase();
        }
    }

    /// <summary>
    /// お手本が光るフェーズ
    /// </summary>
    private void ShinePhase()
    {
        //ここでカウントダウン出したい

        NodeManager.Instance.ShineRandomNodes(ShineNum);
    }

    /// <summary>
    /// 指定回数光らせ終わったら呼び出される
    /// </summary>
    public void FinishShine()
    {
        ChangePhase(Phase.TAP);
    }

    /// <summary>
    /// プレイヤーの入力が終わったら呼び出される(正解)
    /// </summary>
    public void TurnFinishCorrect()
    {
        //正解のエフェクトを出す
        ScoreManager.Instance.Correct();
        ShineNum++;
        ChangePhase(Phase.READY);

    }

    /// <summary>
    /// プレイヤーの入力が終わったら呼び出される(失敗)
    /// </summary>
    public void TurnFinishMiss()
    {
        //失敗のエフェクトを出す

        ChangePhase(Phase.RESULT);
        ResultPhase();
    }

    /// <summary>
    /// 結果フェーズ
    /// </summary>
    private void ResultPhase()
    {
        //スコア表示
    }


    /// <summary>
    /// ゲームを初期化
    /// </summary>
    public void ResetGame()
    {
        ShineNum = 1;
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

    /// <summary>
    /// Phaseを変更
    /// </summary>
    /// <param name="nextPhase"></param>
    private void ChangePhase(Phase nextPhase)
    {
        nowPhase = nextPhase;
    }

}
