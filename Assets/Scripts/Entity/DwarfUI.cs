using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DwarfUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestComboText;

    public void Init(int bestScore, int bestCombo)
    {
        bestScoreText.text = bestScore.ToString();
        bestComboText.text = bestCombo.ToString();
    }

    public void ShowUI(bool isShow)
    {
        canvas.gameObject.SetActive(isShow);
    }
}
