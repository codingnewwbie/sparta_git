using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField]private TextMeshProUGUI timeText;
    [SerializeField]private TextMeshProUGUI endText;


    [SerializeField]private float passedTime;


    public Card firstCard;
    public Card secondCard;
    public int cardCount;

    public bool isEnd = false;

    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    void Start() {
        Time.timeScale = 1.0f;
        isEnd = false;
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if(passedTime >= 30f) {
            GameOver();
        }

        if(!isEnd) {
            passedTime += Time.deltaTime;
            timeText.text = passedTime.ToString("N2");       
        } 
    }

    public void IsMatched() {
        if(firstCard.idx == secondCard.idx) {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if(cardCount == 0) {
                GameOver();
            }
        } else {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = secondCard = null;
    }

    public void Retry() {
        SceneManager.LoadScene("MainScene");
    }

    void GameOver() {
        isEnd = true;
        Time.timeScale = 0f;
        endText.gameObject.SetActive(true);
    }
}
