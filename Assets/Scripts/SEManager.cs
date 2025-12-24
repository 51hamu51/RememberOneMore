using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance { get; private set; }
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    /// <summary>
    /// 指定されたSEを一度だけ流す
    /// </summary>
    /// <param name="audio"></param>
    public void PlayOneTime(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
