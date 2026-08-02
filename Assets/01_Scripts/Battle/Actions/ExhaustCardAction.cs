using System;
using UnityEngine;

public class ExhaustCardAction : IEffectAction
{
    private Character source;
    private Character target;
    private Card card;

    // 여기에서 없앨 카드를 지정해 줘야 할 것 같다. 아니네 본인소멸하면 되겠네
    public ExhaustCardAction(Character _source, Character _target, Card _card)
    {
        source = _source;
        target = _target;
        card = _card;
    }
    public void Execute(BattleContext ctx)
    {
        Debug.LogError("카드 소멸 효과 미구현");
    }
}
