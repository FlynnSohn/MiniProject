using UnityEngine;

public class GainEnergyAction : IEffectAction
{

    private Character source;
    private Character target;
    // defend랑 똑같이, source와 target는 동일한 대상이다.
    private int energy;

    public GainEnergyAction(Character _source, Character _target, int _energy)
    {
        source = _source;
        target = _target;
        energy = _energy;
    }

    public void Execute(BattleContext ctx)
    {
        ctx.Energy.GainEnergy(energy);
    }
}
