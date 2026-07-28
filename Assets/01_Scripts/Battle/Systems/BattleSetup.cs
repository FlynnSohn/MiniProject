using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    [SerializeField] private Monster monsterPrefab;
    [SerializeField] private MonsterSequence monsterSequence;
    [SerializeField] private Player player;

    [SerializeField] private float spacing = 4f;
    [SerializeField] private Vector2 centerPos = new(4f, -0.5f);
    [SerializeField] private int baseSortingOrder = 300;
    [SerializeField] private Deck deck;

    private CardPiles cardPiles;

    public Enemies Enemies { get; private set; }

    private void Start() => Setup();
    void Setup()
    {
        Enemies = new Enemies();

        player.Init(GameManager.instance.Run);
        SpawnMonsters(GameManager.instance.Run.MonsterIndex);

        cardPiles = new CardPiles(deck, 5);

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
    /// <param name="i"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    private Vector2 GetSlotPos(int i, int count)
    {
        float offsetX = (i - (count - 1) / 2f) * spacing;
        return centerPos + new Vector2(offsetX, 0f);
    }

}
