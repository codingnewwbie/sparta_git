using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject square;
    public Text timeTxt;
    public Text nowScore;

    public Text bestScore;

    public GameObject endPanel;

    public Animator anim;

    string key = "BestScore";
    
    float time = 0.0f;

    bool isPlay = true;

    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSqaure", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay) {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
    }

    void MakeSqaure()
    {
        Instantiate(square);
    }

    public void GameOver() {
        isPlay = false;
        anim.SetBool("isDie", true);
        Invoke("TimeStop", 0.3f);
        nowScore.text = time.ToString("N2");
        endPanel.SetActive(true);

        if(PlayerPrefs.HasKey(key)) {
            float best = PlayerPrefs.GetFloat(key);
            if(best < time) {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            } else {
                bestScore.text = best.ToString("N2"); 
            }
        } else {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2"); 
        }
        // 최고 점수가 있으면 현재 점수와 비교해서 더 높을 수를 최고점수에 저장, 
        // 최고 점수가 없으면 현재 점수를 최고점수로 저장.
    }

    public void TimeStop() {
        Time.timeScale = 0.0f;
    }
}
