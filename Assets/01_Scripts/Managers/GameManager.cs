using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void NextBattle() => SceneManager.LoadScene("BattleScene");
    public void GameOver() => SceneManager.LoadScene("TitleScene");
    private RunState runState;

    // 지연 생성
    public RunState Run => runState ??= CreateRun();
    // Runstate는 기본적으로 게임매니저에서 접근

    // 새 게임 시작
    public void StartNewRun() => runState = CreateRun();

    [SerializeField] private CardData strikeCard, defendCard;
    [SerializeField] private CardDataList cardDataList;


    private RunState CreateRun()
    {
        RunState run = new RunState();
        FillStartingDeck(run.Deck);
        return run;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        StartNewRun();
        NextBattle();
    }

    private void FillStartingDeck(Deck deck)
    {
        // 기본 카드 사전 배치
        for (int i = 0; i < 2; i++)
        {
            deck.Add(strikeCard);
            deck.Add(defendCard);
        }
        List<CardData> clonedList = new List<CardData>(cardDataList.CardList);


        // 카드 풀을 복사해서 초기 덱 10장을 채울 때까지 랜덤하게 배분
        while (deck.MyDeck.Count < 10)
        {
            if (clonedList.Count == 0)
            {
                Debug.LogError("카드 후보 풀이 비어 10장을 채울 수 없음");
                break;
            }

            int randomIndex = Random.Range(0, clonedList.Count);

            CardData randomCardData = clonedList[randomIndex];
            deck.Add(randomCardData);
            clonedList.RemoveAt(randomIndex);
        }


    }

}
