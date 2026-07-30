using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private BattleContext ctx;

    public void Begin(BattleContext ctx)
    {
        this.ctx = ctx;
    }

    public void PlayCard(Card card, Character target)
    {
        if (card.NeedsTarget && target == null) return;
        if (!ctx.Energy.CanAfford(card.Cost)) return;
        if (!ctx.CardPiles.TakeFromHand(card)) return;
        ctx.Energy.Spend(card.Cost);
        //foreach 효과 → Set(player, target) → ctx.EnqueueBack(액션);
        ctx.RunQueue();
        ctx.CardPiles.ResolveCardInPlay();
    }
}
