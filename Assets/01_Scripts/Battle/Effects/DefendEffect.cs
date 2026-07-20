using UnityEngine;
using System;


[Serializable]
public class DefendEffect : IEffectBase
{
    [SerializeField] private int defend;
    [SerializeField] private TargetScope scope;
    public IEffectAction Set(Character source, Character target)
    {
        Character receiver = (scope == TargetScope.Self) ? source : target;
        return new GainDefendAction(source, receiver, defend);
    }
}
