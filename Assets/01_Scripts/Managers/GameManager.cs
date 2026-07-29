using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private RunState runState;
    /// <summary>
    /// 지연 생성
    /// </summary>
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

    private void FillStartingDeck(Deck deck)
    {
        for (int i = 0; i < 2; i++)
        {
            deck.Add(strikeCard);
            deck.Add(defendCard);
        }

        for (int i = 0; i < 6; i++)
        {
            CardData randomCardData;
            // 셔플로직실행...? 그냥 랜덤 수로 데이터리스트 인덱스에서 뽑으면 안 될까요? 중복이면 다시 뽑고..
        }
        while (deck.MyDeck.Count < 10)
        {

        }


    }

}
