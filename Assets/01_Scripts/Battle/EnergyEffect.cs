using UnityEngine;

public class EnergyEffect : IEffectBase
{
    private int energy;
    public IEffectAction Set(Character source, Character target) => new GainEnergyAction(source, target, energy);
}
