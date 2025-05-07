using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public enum UIState
{
    Home,
    Game,
    Score,
    Explain,
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    public static UIManager Instance
    {
        get => instance;
    }

    private UIState currentState = UIState.Home;
    private HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;
    ExplainUI explainUI = null;

    private TheStack theStack = null;

    private void Awake()
    {
        instance = this;
        
        theStack = FindObjectOfType<TheStack>();

        homeUI = GetComponentInChildren<HomeUI>(true); // true => 꺼져있는 UI도 포함시킬거냐
        homeUI?.Init(this);
        
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);
        
        explainUI = GetComponentInChildren<ExplainUI>(true);
        
        ChangeState(UIState.Explain);

        // ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
        explainUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
// Hierachy 위의 Play 버튼을 종료하는 것
// #if UNITY_EDITOR
//         UnityEditor.EditorApplication.isPlaying = false;
// #else    
        SceneManager.LoadScene("SampleScene");
    }

    public void onClickHome()
    {
        ChangeState(UIState.Home);
    }

    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.Combo, theStack.BestScore, theStack.MaxCombo);
        ChangeState(UIState.Score);
    }
}
