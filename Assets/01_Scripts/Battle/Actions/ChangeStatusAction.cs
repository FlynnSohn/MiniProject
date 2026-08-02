using System;
using UnityEngine;

public class ChangeStatusAction : IEffectAction
{
    private Character target;
    private StatusType statusType;
    private int amount;

    public ChangeStatusAction(Character _target, StatusType _statusType, int _amount)
    {
        target = _target;
        statusType = _statusType;
        amount = _amount;
    }

    public void Execute(BattleContext ctx)
    {
        StatusEffectBase status = statusType switch
        {
            StatusType.Vulnerable => new VulnerableStatus(amount),
            StatusType.Strength => new StrengthStatus(amount),
            StatusType.Weak => new WeakStatus(amount),
            //StatusType.Poison => new PoisonStatus(amount),
            _ => throw new NotImplementedException($"상태이상 구현 필요 {statusType}")
        };
        target.AddStatus(status);
    }

}
