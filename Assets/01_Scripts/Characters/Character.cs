using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    protected int currentHp;
    protected int currentDefend = 0; // 실시간 방어력
    protected int currentEnergy; // 플레이어만 쓰는 속성

    private List<StatusEffectBase> statusEffects = new();

    public void DealDamage(int amount)
    {
        // 타겟.DealDamage(최종 데미지) 가 실행될 것이다.
        // 그럼 해야 할 것
        // target의 방어를 amount만큼 제거하기
        // 그다음에 amount에서 최초 저장해둔 방어값 빼기 아 좀더 예쁜 식 없나
        // amount>0이면 target의 hp를 amount만큼 깎기
        // target의 체력이 0 이하가 되면 게임오브젝트 파괴

        // target의 방어가 amount보다 큰지 작은지 계산하고
        // 방어가 작으면 amount에서 방어를 뺀 다음 방어를 0으로 만들고 hp에서 amount를 뺌
        // 방어가 크거나 같으면 방어에서 amount를 뺀 다음 끝
        // target의 체력이 0 이하가 되면 죽음 연출 재생되고 게임오브젝트 파괴...
        if (currentDefend < amount)
        {
            amount -= currentDefend;
            currentDefend = 0;
            currentHp -= amount;
        }
        else
        {
            currentDefend -= amount;
        }
        if (currentHp <= 0) Die();
    }
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
