using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    
    private int bestScore = 0;
    private int bestCombo = 0;
    
    private const string BestScoreKey = "TheStackBestScore";
    private const string BestComboKey = "TheStackBestCombo";
    
    void Start()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestCombo = PlayerPrefs.GetInt(BestComboKey, 0);
    }
    
    public void Talk()
    {
        Debug.Log($"{gameObject.name} 상호작용");
        
        Debug.Log($"해당 게임의 최고점수는 {bestScore} 입니다");
        Debug.Log($"해당 게임의 최고콤보수는 {bestCombo} 입니다");
    }
}
