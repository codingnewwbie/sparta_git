using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dwarf : NPCController
{
    [SerializeField] private DwarfUI dwarfUI;
    private bool inClosed = false;
    private bool isUIVisible = false;

    protected override NPCState GetNPCUIState()
    {
        return NPCState.Dwarf;
    }

    public override void Init(NPCManager npcManager)
    {
        base.Init(npcManager);
        dwarfUI.ShowUI(false);
    }

    private void Update()
    {
        if (inClosed && Input.GetKeyDown(KeyCode.F))
        {
            isUIVisible = !isUIVisible;
            dwarfUI.Init(bestScore, bestCombo);
            dwarfUI.ShowUI(isUIVisible);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inClosed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inClosed = false;
            isUIVisible = false;
            dwarfUI.ShowUI(false);
        }
    }
    
    public void ToggleUI()
    {
        isUIVisible = !isUIVisible;
        dwarfUI.Init(bestScore, bestCombo);
        dwarfUI.ShowUI(isUIVisible);
    }
}