using UnityEngine;

public static class DamageCalculator
{
    /// <summary>
    /// 상태이상 순회하며 상태이상 적용 후의 데미지 계산
    /// </summary>
    public static int Calculate(Character source, Character target, int baseDamage)
    {
        return target.EffectAppliedDamageReceived(source.EffectAppliedDamageDealt(baseDamage));
    }
}
