using UnityEngine;


public class BattleSetup : MonoBehaviour
{
    [SerializeField] private Monster monsterPrefab;
    [SerializeField] private MonsterSequence monsterSequence;
    [SerializeField] private Player player;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private DragHandler dragHandler;
    [SerializeField] private HandView handView;
    [SerializeField] private UIManager uiManager;

    [SerializeField] private float spacing = 4f;
    [SerializeField] private Vector2 centerPos = new(4f, -0.5f);
    [SerializeField] private int baseSortingOrder = 300;


    private CardPiles cardPiles;

    public Enemies Enemies { get; private set; }
    public BattleContext Ctx { get; private set; }

    private void Start() => Setup();
    void Setup()
    {
        Enemies = new Enemies();

        player.Init(GameManager.instance.Run);
        SpawnMonsters(GameManager.instance.Run.MonsterIndex);

        cardPiles = new CardPiles(GameManager.instance.Run.Deck);

        Ctx = new BattleContext(player, Enemies, new EnergySystem(3), cardPiles, new ActionQueue());

        uiManager.Begin(Ctx);
        handView.Begin(Ctx);
        dragHandler.Begin(Ctx);
        turnManager.Begin(Ctx);
        turnManager.StartPlayerTurn();


        Debug.Log($"손패 {cardPiles.Hand.Count} / 뽑을 {cardPiles.DrawCount}");

    }



    private void SpawnMonsters(int sequenceIndex)
    {
        MonsterEncounter encounter = monsterSequence.GetAt(sequenceIndex);
        if (encounter == null || encounter.Count == 0)
        {
            Debug.LogError("MonsterSequence가 비었거나 이번 턴에 만날 몬스터 목록이 비었음");
            return;
        }

        int count = encounter.Count;
        for (int i = 0; i < count; i++)
        {
            Monster m = Instantiate(monsterPrefab);
            m.Init(encounter.Monsters[i]);
            m.transform.position = GetSlotPos(i, count);
            m.SetSortingOrder(baseSortingOrder + i * 10);
            Enemies.Add(m);
        }
    }
    /// <summary>
    /// 몬스터 중앙 기준 균등 배치
    /// </summary>
    private Vector2 GetSlotPos(int i, int count)
    {
        float offsetX = (i - (count - 1) / 2f) * spacing;
        return centerPos + new Vector2(offsetX, 0f);
    }

}
