using System;
using UnityEngine;


[Serializable]
public class HealEffect : IEffectBase
{
    [SerializeField] private int hp;
    [SerializeField] private TargetScope scope;
    public TargetScope Scope => scope;

    public IEffectAction Set(Character source, Character target) => new HealHpAction(source, target, hp);

}
