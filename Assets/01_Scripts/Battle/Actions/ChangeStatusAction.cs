using UnityEngine;

public class ChangeStatusAction : IEffectAction
{
    private Character source;
    private Character target;
    private StatusEffectBase statusEffect;
    private int amount;

    public ChangeStatusAction(Character _source, Character _target, StatusEffectBase _statusEffect, int _amount)
    {
        source = _source;
        target = _target;
        statusEffect = _statusEffect;
        amount = _amount;
    }

    public void Execute()
    {
        target.AddStatus(statusEffect);
    }

}
