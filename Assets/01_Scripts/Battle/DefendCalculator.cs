
public static class DefendCalculator
{
    public static int Calculate(Character owner, int baseDefend)
    {
        return owner.EffectAppliedDefendGained(baseDefend);
    }

}
