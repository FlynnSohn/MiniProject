using UnityEngine;
using System;


[Serializable]
public class EnergyEffect : IEffectBase
{
    [SerializeField] private int energy; // 에너지를 잃을 땐 음수값으로 넣기
    [SerializeField] private TargetScope scope;
    public TargetScope Scope => scope;
    public IEffectAction Set(Character source, Character target) => new GainEnergyAction(source, target, energy);
}
