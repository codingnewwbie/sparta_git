using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private static NPCManager instance;
    
    public static NPCManager Instance
    {
        get => instance;
    }
    
    private Dwarf dwarf = null;
    private Elf elf = null;

    private void Awake()
    {
        instance = this;
        
        dwarf = GetComponentInChildren<Dwarf>(true); // true => 꺼져있는 UI도 포함시킬거냐
        dwarf?.Init(this);
        
        elf = GetComponentInChildren<Elf>(true);
        elf?.Init(this);
        
        
        
    }

    // public void ChangeNPCState(NPCState state)
    // {
    //     currentState = state;
    //     dwarf?.SetActive(currentState);
    // }
}
