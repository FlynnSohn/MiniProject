using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Monster : Character
{
    private IReadOnlyList<MonsterPatternData> monsterPatternData;
    private int patternIndex;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI hpText;
    private SpriteRenderer sr;
    private BoxCollider2D monsterCollider;
    MonsterData monsterData;
    public void Init(MonsterData data)
    {
        monsterData = data;
        // this.InitStats(data.MaxHp, data.MaxHp);
        // monsterPatternData = data.MonsterPatterns;
        this.InitStats(monsterData.MaxHp, monsterData.MaxHp);
        monsterPatternData = monsterData.MonsterPatterns;
        hpText.text = currentHp.ToString();
        //nameText.text = data.MonsterName;
        nameText.text = monsterData.MonsterName;
        patternIndex = 0;

    }
    void Awake()
    {
        sr = monsterData.GetComponent<SpriteRenderer>();
        monsterCollider.size = monsterData.MonsterImage.bounds.size;
        monsterCollider = GetComponent<BoxCollider2D>();
    }


}
