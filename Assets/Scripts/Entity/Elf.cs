using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : NPCController
{
    [SerializeField] private ElfUI elfUI;

    public override void Init(NPCManager npcManager)
    {
        base.Init(npcManager);
        elfUI.ShowUI(false);
    }
    
    public override void Interact()
    {
        elfUI.Init(bestScore, bestCombo);
        elfUI.ShowUI(true);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        elfUI.ShowUI(false);
    }
}
