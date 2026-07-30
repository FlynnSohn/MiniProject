using System;
using UnityEngine;


[Serializable]
public class DamageEffect : IEffectBase
{
    [SerializeField] private int damage;
    [SerializeField] private TargetScope scope;
    public TargetScope Scope => scope;

    public IEffectAction Set(Character source, Character target)
    {
        Character receiver = (scope == TargetScope.Self) ? source : target;
        return new DealDamageAction(source, receiver, damage);
    }
}
