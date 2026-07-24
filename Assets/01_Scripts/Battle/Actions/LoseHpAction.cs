
public class LoseHpAction : IEffectAction
{

    private Character source;
    private Character target;
    // 하...일단 두자
    private int amount;

    public LoseHpAction(Character _source, Character _target, int _amount)
    {
        source = _source;
        target = _target;
        amount = _amount;
    }

    public void Execute(BattleContext ctx)
    {
        source.LoseHp(amount);
    }
}
