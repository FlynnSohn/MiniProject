using UnityEngine;
using System;

[Serializable]
public class LoseHpEffect : IEffectBase
{
    [SerializeField] private int amount;
    [SerializeField] private TargetScope scope;
    public TargetScope Scope => scope;

    public IEffectAction Set(Character source, Character target)
    {
        Character receiver = (scope == TargetScope.Self) ? source : target;
        return new GainDefendAction(source, receiver, amount);
    }

}
