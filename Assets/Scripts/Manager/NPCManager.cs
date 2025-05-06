using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NPCState
{
    None,
    Dwarf,
    Elf,
}

public class NPCManager : MonoBehaviour
{
    private static NPCManager instance;
    
    public static NPCManager Instance
    {
        get => instance;
    }
    
    private NPCState currentState = NPCState.None;
    private Dwarf dwarf = null;
    private Elf elf = null;

    private void Awake()
    {
        instance = this;
        
        dwarf = GetComponentInChildren<Dwarf>(true); // true => 꺼져있는 UI도 포함시킬거냐
        dwarf?.Init(this);
        
        // ChangeNPCState(NPCState.Dwarf);

    }

    // public void ChangeNPCState(NPCState state)
    // {
    //     currentState = state;
    //     dwarf?.SetActive(currentState);
    // }
}
