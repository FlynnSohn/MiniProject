using UnityEngine;

public class DefendEffect : IEffectBase
{
    private int defend;
    public IEffectAction Set(Character source, Character target)
    {
        return new GainDefendAction(source, target, defend);
    }
}
