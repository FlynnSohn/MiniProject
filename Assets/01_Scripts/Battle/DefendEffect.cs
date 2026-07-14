using UnityEngine;

public class DefendEffect : IEffectBase
{
    [SerializeField] private int defend;
    public IEffectAction Set(Character source, Character target)
    {
        return new GainDefendAction(source, target, defend);
    }
}
