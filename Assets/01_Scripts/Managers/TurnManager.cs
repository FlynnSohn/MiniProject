using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private BattleContext ctx;

    public void Begin(BattleContext ctx)
    {
        this.ctx = ctx;
    }

    public void StartPlayerTurn()
    {
        ctx.Energy.ResetToDefault();
        //ctx.Player.D
        ctx.CardPiles.Draw(5);

    }
    public void EndPlayerTurn()
    {
        ctx.CardPiles.DiscardHand();
    }

    public void StartEnemyTurn(int enemyIndex)
    {

    }

    public void PlayCard(Card card, Character target)
    {
        int c = card.Cost;
        if (card.NeedsTarget && target == null) return;
        if (!ctx.Energy.CanAfford(c)) return;
        if (!ctx.CardPiles.TakeFromHand(card)) return;
        ctx.Energy.Spend(c);

        foreach (var effect in card.Data.CardEffects)
        {
            IEffectAction action = effect.Set(ctx.Player, target);
            if (action == null)
            {
                Debug.LogError($"{card.Data.CardName}효과가 액션을 만들지 못함");
                continue;
            }
            ctx.EnqueueBack(action);
        }

        ctx.RunQueue();
        ctx.CardPiles.ResolveCardInPlay();
    }
}
