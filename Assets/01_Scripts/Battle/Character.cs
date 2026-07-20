using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    private int currentHp;
    private int currentDefend; // 실시간 방어력
    private int currentEnergy;

    private List<StatusEffectBase> statusEffects = new();


    public void DealDamage(int amount) { }
    public void LoseHp(int amount) { }
    public void GainDefend(int amount) { currentDefend += amount; }
    public void GainEnergy(int amount) { currentEnergy += amount; }
    public void DrawCard(int count) { }
    public void HealHp(int amount) { currentHp += amount; }
    public void ExhaustCard(GameObject card) { }

    // 적용된 상태이상에 동일 상태이상이 있는지 확인해 있으면 스택 값을 더하고 없으면 상태이상을 추가
    public void AddStatus(StatusEffectBase newStatus)
    {
        StatusEffectBase existing = statusEffects.Find(s => s.GetType() == newStatus.GetType());
        if (existing != null) existing.AddStack(newStatus.Stack);
        else statusEffects.Add(newStatus);
    }
    public void RemoveStatus(StatusEffectBase statusEffect)
    {
        statusEffects.Remove(statusEffect);
    }

    // 딜량, 방어력 등에 현재 적용된 상태이상 값 반영하는 함수 3개
    // public int EffectAppliedDamageDealt(int dmg)
    // {
    //     foreach (var s in statusEffects)
    //     {
    //         dmg = s.ChangeDamageDealing(dmg);
    //     }
    //     return dmg;
    // }
    // public int EffectAppliedDamageReceived(int dmg)
    // {
    //     foreach (var s in statusEffects)
    //     {
    //         dmg = s.ChangeDamageReceived(dmg);
    //     }
    //     return dmg;
    // }
    // public int EffectAppliedDefendGained(int defend)
    // {
    //     foreach (var s in statusEffects)
    //     {
    //         defend = s.ChangeDefendGained(defend);
    //     }
    //     return defend;
    // }

    public int SumDamageDealtBonus()
    {
        int sum = 0;
        foreach (var s in statusEffects) sum += s.GetDamageDealtBonus();
        return sum;
    }
    public float TotalDamageDealtMultiplier()
    {
        float total = 1f;
        foreach (var s in statusEffects) total *= s.GetDamageDealtMultiplier();
        return total;
    }
    public int SumDamageReceivedBonus()
    {
        int sum = 0;
        foreach (var s in statusEffects) sum += s.GetDamageReceivedBonus();
        return sum;
    }
    public float TotalDamageReceivedMultiplier()
    {
        float total = 1f;
        foreach (var s in statusEffects) total *= s.GetDamageReceivedMultiplier();
        return total;
    }
    public int SumDefendGainedBonus()
    {
        int sum = 0;
        foreach (var s in statusEffects) sum += s.GetDefendGainedBonus();
        return sum;
    }
    public float TotalDefendGainedMultiplier()
    {
        float total = 1f;
        foreach (var s in statusEffects) total *= s.GetDefendGainedMultiplier();
        return total;
    }
}
