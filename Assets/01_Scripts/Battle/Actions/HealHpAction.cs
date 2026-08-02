using System;
using UnityEngine;

public class HealHpAction : IEffectAction
{
    private Character source;
    private Character target;
    private int hp;

    public HealHpAction(Character _source, Character _target, int _hp)
    {
        source = _source;
        target = _target;
        hp = _hp;
    }
    public void Execute(BattleContext ctx)
    {
        target.HealHp(hp);
    }

}
