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
    [SerializeField] StatusType statusType;
    public IEffectAction Set(Character source, Character target)
    {
        return new ChangeStatusAction(source, target, statusType, stack);
    }
}
