using System;
using System.Collections.Generic;
using UnityEngine;
//



public class Monster : Character
{
    private IReadOnlyList<MonsterPatternData> monsterPatternData;
    private int patternIndex;
    private MonsterPatternData nextPattern; // 이번에 예고

    //[SerializeField] TextMeshProUGUI nameText;
    //[SerializeField] TextMeshProUGUI hpText;
    [SerializeField] private CharacterView characterView;
    private SpriteRenderer sr;
    private BoxCollider2D monsterCollider;

    public MonsterPatternData NextPattern => nextPattern;
    public event Action OnIntentChanged;

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
    /// 행동을 고르고 인덱스 증가, 실행코드는 아님
    /// </summary>
    public void DecideIntent()
    {
        if (monsterPatternData == null || monsterPatternData.Count == 0)
        {
            Debug.LogError($"{name}: 패턴이 비었음", this);
            nextPattern = null;
            return;
        }

        nextPattern = monsterPatternData[patternIndex];
        patternIndex = (patternIndex + 1) % monsterPatternData.Count;
        OnIntentChanged?.Invoke();
    }

    /// <summary>
    /// 예고 행동의 효과를 큐에 쌓아두기
    /// </summary>
    /// <param name="ctx"></param>
    public void ActOnIntent(BattleContext ctx)
    {
        if (nextPattern == null) return;

        IReadOnlyList<IEffectBase> effects = nextPattern.MonsterEffectPatterns;
        for (int i = 0; i < effects.Count; i++)
        {
            IEffectAction action = effects[i].Set(this, ctx.Player);
            if (action == null)
            {
                Debug.LogError($"{name}: 패턴 {i}가 액션을 만들지 못함", this);
                continue;
            }
            ctx.EnqueueBack(action);
        }

    }

    /// <summary>
    /// 외부(BattleSetup)에서 지정하는 것들
    /// </summary>
    public void SetSortingOrder(int order) => sr.sortingOrder = order;
    public override void Die() => gameObject.SetActive(false);
}
