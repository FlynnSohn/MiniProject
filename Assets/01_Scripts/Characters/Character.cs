using UnityEngine;
using System.Collections.Generic;
using System;

public class Character : MonoBehaviour
{
    protected int maxHp;
    protected int currentHp;
    protected int currentDefend = 0; // 실시간 방어력


    public event Action OnStatsChanged;


    public bool IsDead => currentHp <= 0;

    private List<StatusEffectBase> statusEffects = new();
    //public IReadOnlyList<StatusEffectBase> StatusEffects => statusEffects;
    protected void InitStats(int _maxHp, int _currentHp)
    {
        maxHp = _maxHp;
        currentHp = _currentHp;
        statusEffects.Clear();
        currentDefend = 0;
        OnStatsChanged?.Invoke();
    }

    public void DealDamage(int amount)
    {

        int blocked = Mathf.Min(currentDefend, amount);
        currentDefend -= blocked;
        //currentHp -= (amount - blocked);
        currentHp = Mathf.Max(currentHp - (amount - blocked), 0);
        OnStatsChanged?.Invoke();
    }
    public void LoseHp(int amount)
    {
        currentHp = Mathf.Max(currentHp - amount, 0);
        OnStatsChanged?.Invoke();
    }
    public void HealHp(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        OnStatsChanged?.Invoke();
    }
    //public void DrawCard(int count) { }
    //public void ExhaustCard(GameObject card) { }
    public void GainDefend(int amount)
    {
        currentDefend += amount;
        OnStatsChanged?.Invoke();
    }
    //public void GainEnergy(int amount) { currentEnergy += amount; }


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
    public virtual void Die()
    {

    }



    // 딜량, 방어력 등에 현재 적용된 상태이상 값 반영하는 함수
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



