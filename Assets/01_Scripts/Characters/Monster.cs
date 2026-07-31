using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;


public class Monster : Character
{
    private IReadOnlyList<MonsterPatternData> monsterPatternData;
    private int patternIndex;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI hpText;
    private SpriteRenderer sr;
    private BoxCollider2D monsterCollider;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        monsterCollider = GetComponent<BoxCollider2D>();
    }
    public void Init(MonsterData data)
    {

        InitStats(data.MaxHp, data.MaxHp);
        monsterPatternData = data.MonsterPatterns;
        patternIndex = 0;

        sr.sprite = data.MonsterImage;
        monsterCollider.size = data.MonsterImage.bounds.size;

        nameText.text = data.MonsterName;

        OnStatsChanged += RefreshHpText;

    }

    /// <summary>
    /// 외부(BattleSetup)에서 지정하는 것들
    /// </summary>
    public void RefreshHpText()
    {
        hpText.text = $"{currentHp}/{maxHp}";
    }
    public void SetSortingOrder(int order) => sr.sortingOrder = order;
    public override void Die() => gameObject.SetActive(false);
}
