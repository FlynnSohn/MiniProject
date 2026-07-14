using UnityEngine;

public class Character : MonoBehaviour
{
    private int currentHp;
    private int currentDefend;
    private int currentEnergy;

    public void DealDamage(int amount) { }
    public void GainDefend(int amount) { currentDefend += amount; }
    public void GainEnergy(int amount) { currentEnergy += amount; }
    public void DrawCard(int count) { }
    public void HealHp(int amount) { currentHp += amount; }
}
