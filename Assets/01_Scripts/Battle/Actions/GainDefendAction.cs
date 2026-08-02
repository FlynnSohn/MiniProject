

public class GainDefendAction : IEffectAction
{
    private Character source;
    private Character target;
    // 여기에서 사실상 source와 target는 동일한 대상이다. 주체랑 적용대상이 헷갈리니까 그냥 둘다 쓰자.
    private int defend;

    public GainDefendAction(Character _source, Character _target, int _defend)
    {
        source = _source;
        target = _target;
        defend = _defend;
    }

    public void Execute(BattleContext ctx)
    {
        int finalDefend = DefendCalculator.Calculate(source, defend);
        source.GainDefend(finalDefend);
    }

}
