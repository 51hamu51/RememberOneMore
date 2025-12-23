using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeManager : MonoBehaviour
{
    public static NodeManager Instance { get; private set; }
    public GameObject[] nodes;

    [Header("光る時間")]
    [SerializeField] private float shineDuration;
    [SerializeField] private float interval;

    [Header("タップされたとき用")]
    public float tapScale;
    public float tapDuration;

    /// <summary>
    /// 正解のノード順
    /// </summary>
    private List<int> correctSequence = new List<int>();

    /// <summary>
    /// 現在の入力位置
    /// </summary>
    private int inputIndex;

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
        NodeReset();
    }

    void Update()
    {

    }

    /// <summary>
    /// ランダムなノードを指定回数光らせる
    /// </summary>
    /// <param name="num"></param>
    public void ShineRandomNodes(int num)
    {
        StartCoroutine(ShineRandomCoroutine(num));
    }

    private IEnumerator ShineRandomCoroutine(int num)
    {
        NodeReset();
        yield return new WaitForSeconds(interval);

        for (int i = 0; i < num; i++)
        {
            int randomIndex = Random.Range(0, nodes.Length);
            correctSequence.Add(randomIndex);
            ShineSpecificNode(nodes[randomIndex]);

            yield return new WaitForSeconds(shineDuration);

            ResetSpecificNode(nodes[randomIndex]);

            yield return new WaitForSeconds(interval);
        }


        GameManager.Instance.FinishShine();
    }

    /// <summary>
    /// 指定されたノードを光らせる
    /// </summary>
    private void ShineSpecificNode(GameObject nodeObj)
    {
        Node node = nodeObj.GetComponent<Node>();
        if (node != null)
        {
            node.Shine();
        }
    }

    /// <summary>
    /// 指定されたノードを元に戻す
    /// </summary>
    private void ResetSpecificNode(GameObject nodeObj)
    {
        Node node = nodeObj.GetComponent<Node>();
        if (node != null)
        {
            node.ResetColor();
        }
    }

    /// <summary>
    /// タップされたノードを取得
    /// </summary>
    /// <param name="id"></param>
    public void OnNodeTapped(int id)
    {
        // 範囲外ガード
        if (inputIndex >= correctSequence.Count)
            return;

        // 正誤判定
        if (id == correctSequence[inputIndex])
        {
            Debug.Log("正解！");
            inputIndex++;

            // 全部正解したら
            if (inputIndex >= correctSequence.Count)
            {
                Debug.Log("オールクリア！");
                GameManager.Instance.TurnFinishCorrect();
            }
        }
        else
        {
            Debug.Log("ミス！");
            GameManager.Instance.TurnFinishMiss();
        }
    }

    /// <summary>
    /// ノードの初期化
    /// </summary>
    private void NodeReset()
    {
        correctSequence.Clear();
        inputIndex = 0;
    }
}
