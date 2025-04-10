using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public void Setting(int number) {
        idx = number;
        
        frontImage.sprite = Resources.Load<Sprite>($"Images/rtan{idx}"); //경로
        
    }

    public void OpenCard() {
        if(!GameManager.Instance.isEnd) {
            anim.SetBool("isOpen", true);
         front.SetActive(true);
         back.SetActive(false);
         
         if(GameManager.Instance.firstCard == null) {
            GameManager.Instance.firstCard = this;
    } else {
        GameManager.Instance.secondCard = this;
        GameManager.Instance.IsMatched();
        }
        }
    }

    public void DestroyCard() {
        Invoke(nameof(DestroyCardInvoke), 1.0f);
    }

    private void DestroyCardInvoke() {
        Destroy(this.gameObject);
    }

    public void CloseCard() {
        Invoke(nameof(CloseCardInvoke), 1.0f);
    }


    private void CloseCardInvoke() {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }


}
