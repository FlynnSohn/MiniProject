using UnityEngine;

public class DealDamageAction : IEffectAction
{
    private Character source;
    private Character target;
    private int damage;


    public DealDamageAction(Character _source, Character _target, int _damage)
    {
        source = _source;
        target = _target;
        damage = _damage;
    }
    public void Execute()
    {
        // 카드 효과에서 온 데미지를 상대에게 적용.
        target.DealDamage(damage);
    }

}
