using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    void Start()
    {
        if (restartText == null)
        {
            Debug.Log("재시작 텍스트가 널임");
        }
        
        if (scoreText == null)
        {
            Debug.Log("스코어 텍스트가 널임");
        }

        restartText.gameObject.SetActive(false);
        
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
