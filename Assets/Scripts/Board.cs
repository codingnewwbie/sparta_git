using System.Linq;
using UnityEngine;


public class Board : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefabs;
    
    void Start()
    {
        CreateCard();
    }

    private void CreateCard() {

        //카드 섞기 셔플
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7,};
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray(); // 람다식, goes to라고 읽음

        for(int i = 0; i < 16; i++) {
            GameObject card = Instantiate(cardPrefabs, this.transform);
            
            card.name = $"Card_{i:00}";

            float x = (i % 4) * 1.1f - 1.65f; //1.1f = 마진값
            float y = (i / 4) * 1.1f - 2.44f; //1.1f = 마진값, - 값들은 0번 카드로 원점 잡기

            card.transform.position = new Vector2(x, y);
            
            card.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
