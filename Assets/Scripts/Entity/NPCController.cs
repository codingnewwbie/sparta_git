using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class NPCController : MonoBehaviour
{
    protected NPCManager npcManager;
    
    protected int bestScore = 0;
    protected int bestCombo = 0;
    
    private const string BestScoreKey = "TheStackBestScore";
    private const string BestComboKey = "TheStackBestCombo";

    public virtual void Init(NPCManager npcManager)
    {
        this.npcManager = npcManager;
        
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestCombo = PlayerPrefs.GetInt(BestComboKey, 0);
    }

    public abstract void Interact();
}
