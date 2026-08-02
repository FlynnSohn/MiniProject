using System;
using UnityEngine;

public enum StatusType
{
    Strength = 0,
    Vulnerable = 1,
    Weak = 2,
    Poison = 3
}



[Serializable]
public class StatusEffect : IEffectBase
{
    [SerializeField] private int stack;
    [SerializeField] private StatusType statusType;
    [SerializeField] private TargetScope scope;
    public TargetScope Scope => scope;

    public IEffectAction Set(Character source, Character target)
    {
        Character receiver = (scope == TargetScope.Self) ? source : target;
        return new ChangeStatusAction(receiver, statusType, stack);
    }
}
