using UnityEngine;
using System;

public class WeakStatus : StatusEffectBase
{
    // 약화: 공격력 25%p 감소
    public WeakStatus(int amount)
    {
        Stack = amount;
    }
    //public override int ChangeDamageDealing(int dmg) => (int)(dmg * 0.75); // 내 공격력에 영향주는거, 힘/약화
    public override float GetDamageDealtMultiplier() => 0.75f;
    public override void OnTurnStart(Character owner, BattleContext ctx)
    {
        Stack--;
        if (Stack <= 0)
        {
            owner.RemoveStatus(this);
        }
    }
}
