using UnityEngine;

public class ChangeStatusAction : IEffectAction
{
    private Character source;
    private Character target;
    private StatusType statusType;
    private int amount;

    public ChangeStatusAction(Character _source, Character _target, StatusType _statusType, int _amount)
    {
        source = _source;
        target = _target;
        statusType = _statusType;
        amount = _amount;
    }

    public void Execute()
    {
        // StatusEffectBase newStatusEffect = statusEffect.CreateInstance(amount); // 추상클래스 인스턴스 만들기
        // source.AddStatus(newStatusEffect);
        // target.AddStatus(newStatusEffect);
    }

}
