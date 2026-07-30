
using System;


/// <summary>
/// 전투 중 상태들 전달 용도
/// </summary>
public class BattleContext
{
    public Player Player { get; }
    public Enemies Enemies { get; }
    public EnergySystem Energy { get; }
    public CardPiles CardPiles { get; }

    private readonly ActionQueue actionQueue; // 카드 임의로 뽑아오는 기능은 없다고 가정

    public BattleContext(Player p, Enemies e, EnergySystem en, CardPiles cp, ActionQueue q)
    {
        if (p == null)
            throw new ArgumentNullException(nameof(p));
        else if (e == null)
            throw new ArgumentNullException(nameof(e));
        else if (en == null)
            throw new ArgumentNullException(nameof(en));
        else if (cp == null)
            throw new ArgumentNullException(nameof(cp));
        else if (q == null)
            throw new ArgumentNullException(nameof(q));



        Player = p;
        Enemies = e;
        Energy = en;
        CardPiles = cp;
        actionQueue = q;
    }

    public void EnqueueFront(IEffectAction a) => actionQueue.PushFront(a);
    public void EnqueueBack(IEffectAction a) => actionQueue.PushBack(a);
    public void RunQueue() => actionQueue.RunAll(this);
}
