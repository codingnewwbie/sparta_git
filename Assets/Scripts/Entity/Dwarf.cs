using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dwarf : NPCController
{
    [SerializeField] private DwarfUI dwarfUI;
    
    public override void Init(NPCManager npcManager)
    {
        base.Init(npcManager);
        dwarfUI.ShowUI(false);
    }
    
    public override void Interact()
    {
        dwarfUI.Init(bestScore, bestCombo);
        dwarfUI.ShowUI(true);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        dwarfUI.ShowUI(false);
    }
}