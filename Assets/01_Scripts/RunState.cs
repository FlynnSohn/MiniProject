using UnityEngine;

public class RunState
{
    public int MaxHp { get; private set; }
    public int CurrentHp { get; private set; }
    public int Gold { get; private set; }
    public int MonsterIndex { get; private set; } // 몬스터 시퀀스 진행 체크
    public int ClearCount { get; private set; } // 몇탄까지 깼는지 점수

    public Deck Deck { get; private set; }

    /// <summary>
    /// 게임 시작할 때 실행
    /// </summary>
    /// <param name="maxHp"></param>
    public RunState(int maxHp = 80)
    {
        MaxHp = maxHp;
        CurrentHp = maxHp;
        Gold = 0;
        MonsterIndex = 0;
        ClearCount = 0;
        Deck = new Deck();
    }

    public void SetHp(int hp) => CurrentHp = Mathf.Clamp(hp, 0, MaxHp);
    public void AddGold(int amount) => Gold += amount;

    public void OnBattleCleared()
    {
        ClearCount++;
        MonsterIndex++;
    }
    public void StartNewRun()
    {
        RunState newRun = new RunState(80);
    }

}
