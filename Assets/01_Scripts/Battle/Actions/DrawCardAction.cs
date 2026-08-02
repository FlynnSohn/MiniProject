using UnityEngine;

public class DrawCardAction : IEffectAction
{
    private Character source;
    private Character target;
    // 여기에서 사실상 source와 target는 동일한 대상이다. 주체랑 적용대상이 헷갈리니까 그냥 둘다 쓰자.
    private int draw;

    public DrawCardAction(Character _source, Character _target, int _draw)
    {
        source = _source;
        target = _target;
        draw = _draw;
    }

    public void Execute(BattleContext ctx)
    {
        ctx.CardPiles.Draw(draw);
    }
}
