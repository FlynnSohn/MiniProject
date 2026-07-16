using System;
using UnityEngine;

[Serializable]
public class StatusEffect : IEffectBase
{
    [SerializeField] private int stack;
    [SerializeField] StatusEffectBase statusEffect;
    public IEffectAction Set(Character source, Character target)
    {
        return new ChangeStatusAction(source, target, statusEffect, stack);
    }
}
