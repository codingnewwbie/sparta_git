using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainUI : BaseUI
{
    private Button nextButton;
    
    protected override UIState GetUIState()
    {
        return UIState.Explain;
    }
    
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        
        nextButton = transform.Find("ExplainButton").GetComponent<Button>();
        
        nextButton.onClick.AddListener(OnClickNextButton);
    }
    
    
    void OnClickNextButton()
    {
        uiManager.onClickHome();
    }
}
