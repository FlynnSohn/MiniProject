using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    private int currentHp;
    private int currentDefend; // 실시간 방어력
    private int currentEnergy;

    private List<StatusEffect> statusEffects = new();

    public void DealDamage(int amount) { }
    public void GainDefend(int amount) { currentDefend += amount; }
    public void GainEnergy(int amount) { currentEnergy += amount; }
    public void DrawCard(int count) { }
    public void HealHp(int amount) { currentHp += amount; }
    public void ExhaustCard(GameObject card) { }
}
