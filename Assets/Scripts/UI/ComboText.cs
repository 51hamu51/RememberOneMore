using UnityEngine;
using TMPro;

public class ComboText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboText;
    void Start()
    {

    }

    void Update()
    {
        comboText.text = ScoreManager.Instance.GetCombo() + " コンボ";
    }
}
