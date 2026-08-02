using System.Collections.Generic;
using UnityEngine;
//



public class Monster : Character
{
    private IReadOnlyList<MonsterPatternData> monsterPatternData;
    private int patternIndex;

    //[SerializeField] TextMeshProUGUI nameText;
    //[SerializeField] TextMeshProUGUI hpText;
    [SerializeField] private CharacterView characterView;
    private SpriteRenderer sr;
    private BoxCollider2D monsterCollider;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        monsterCollider = GetComponent<BoxCollider2D>();
        //OnStatsChanged += RefreshHpText;
    }
    public void Init(MonsterData data)
    {

        InitStats(data.MaxHp, data.MaxHp);
        monsterPatternData = data.MonsterPatterns;
        patternIndex = 0;

        sr.sprite = data.MonsterImage;
        monsterCollider.size = data.MonsterImage.bounds.size;

        //nameText.text = data.MonsterName;
        characterView.SetName(data.MonsterName);

    }

    /// <summary>
    /// 외부(BattleSetup)에서 지정하는 것들
    /// </summary>
    public void SetSortingOrder(int order) => sr.sortingOrder = order;
    public override void Die() => gameObject.SetActive(false);
}
