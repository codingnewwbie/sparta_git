using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElfUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    [SerializeField] private Button applyButton;
    private int requiredScore = 30;
    private int requiredCombo = 2;
    [SerializeField] private StatController statController;
    
    [SerializeField] private Animator playerAnimator;
    

    public void Init(int bestScore, int bestCombo)
    {
        bool isUnlock = bestScore >= requiredScore && bestCombo >= requiredCombo;
        applyButton.gameObject.SetActive(isUnlock);
        
        applyButton.onClick.RemoveAllListeners();
        applyButton.onClick.AddListener(() =>
        {
            if (isUnlock)
            {
                playerAnimator.SetTrigger("IsSkin");
                statController.SetSpeed(10f);
                PlayerPrefs.SetInt("SkinIndex", 1);
                Debug.Log("스킨이 적용되었습니다.");
            }
            else
            {
                Debug.Log("스킨 조건이 만족하지 않습니다.");
            }
        });
    }

    public void ShowUI(bool isShow)
    {
        canvas.gameObject.SetActive(isShow);
    }
}
