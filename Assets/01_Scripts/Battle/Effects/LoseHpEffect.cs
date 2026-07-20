using UnityEngine;
using System;

[Serializable]
public class LoseHpEffect : IEffectBase
{
    [SerializeField] private int amount;
    [SerializeField] private TargetScope scope; // 필요할까? 
    public IEffectAction Set(Character source, Character target)
    {
        Character receiver = (scope == TargetScope.Self) ? source : target;
        return new GainDefendAction(source, receiver, amount);
    }

}
