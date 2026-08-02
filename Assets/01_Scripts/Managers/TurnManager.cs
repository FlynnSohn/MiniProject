using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private BattleContext ctx;
    private bool battleEnded;

    public void Begin(BattleContext ctx)
    {
        this.ctx = ctx;
    }

    public void StartPlayerTurn()
    {
        if (battleEnded) return;

        ctx.Player.ResetDefend(); // 방어도 리셋
        ctx.Player.TurnStart(ctx);
        ctx.RunQueue(); // 중독 처리 후 죽었는지 체크
        CheckBattleEnd();
        if (battleEnded) return; // 중독 사망

        ctx.Energy.ResetToDefault();
        ctx.CardPiles.Draw(5);
        // 몹 의도 UI 걍신 
    }
    public void EndPlayerTurn()
    {
        if (battleEnded) return;

        ctx.CardPiles.DiscardHand();
        ctx.Player.TurnEnd(ctx);
        ctx.RunQueue();
        CheckBattleEnd();
        if (battleEnded) return;

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        List<Monster> aliveMonsters = new List<Monster>(ctx.Enemies.GetAliveMonsters());

        foreach (Monster m in aliveMonsters)
        {
            if (m.IsDead) continue;
            m.ResetDefend();
            m.TurnStart(ctx);
            // 예고 의도 실행
            m.TurnEnd(ctx);
        }
        ctx.RunQueue();
        CheckBattleEnd();
        if (battleEnded) return;

        StartPlayerTurn();
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
        CheckBattleEnd();
    }
    private void CheckBattleEnd()
    {
        if (battleEnded) return;
        if (ctx.Player.IsDead) { EndBattle(false); return; }
        if (ctx.Enemies.AllMonstersDead) { EndBattle(true); }
    }
    private void EndBattle(bool won)
    {
        battleEnded = true;
        RunState run = GameManager.instance.Run;
        run.SetHp(ctx.Player.CurrentHp);

        if (won)
        {
            run.OnBattleCleared();
            run.AddGold(15);
            Debug.Log($"승리! 클리어 횟수: {run.ClearCount}");
            // 보상화면 -> 다음 전투
        }
        else
        {
            Debug.Log($"게임오버! 최종 점수: {run.ClearCount}");
            // 결과 화면
        }
    }
}
