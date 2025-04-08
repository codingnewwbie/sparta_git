using System;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreTxt;
    public Text totalTimeTxt;
    
    int totalScore = 0;

    float totalTime = 5.0f;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime > 0) {
            totalTime -= Time.deltaTime;
        } else {
            totalTime = 0f;
            Time.timeScale = 0f;
            endPanel.SetActive(true);
        }
        totalTimeTxt.text = totalTime.ToString("N2");
    }

    void MakeRain() 
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
        Debug.Log(totalScore);
    }

}
