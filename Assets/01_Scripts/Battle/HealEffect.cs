using UnityEngine;

public class HealEffect : IEffectBase
{
    [SerializeField] private int hp;
    public IEffectAction Set(Character source, Character target) => new HealHpAction(source, target, hp);

}
