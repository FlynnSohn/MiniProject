using UnityEngine;

public class DamageEffect : IEffectBase
{
    private int damage;
    public IEffectAction Set(Character source, Character target)
    {
        return new DealDamageAction(source, target, damage);
    }
}
