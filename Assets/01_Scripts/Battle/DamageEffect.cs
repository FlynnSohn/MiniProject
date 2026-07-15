using System;
using UnityEngine;
[Serializable]
public class DamageEffect : IEffectBase
{
    [SerializeField] private int damage;
    // 체력을 얻을 땐 여기에 음수값을 쓸까...?
    public IEffectAction Set(Character source, Character target)
    {
        return new DealDamageAction(source, target, damage);
    }
}
