using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public enum Mode
    {
        CHALLENGE,//だんだん増えていく
        ENDLESS,//ずっと一定
    }

    /// <summary>
    /// 選ばれたモード
    /// </summary>
    private Mode nowMode;

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

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 現在のモードを取得
    /// </summary>
    /// <returns></returns>
    public Mode GetMode()
    {
        return nowMode;
    }

    /// <summary>
    /// モードを変更
    /// </summary>
    /// <param name="mode"></param>
    public void ChangeMode(Mode mode)
    {
        nowMode = mode;
    }
}
