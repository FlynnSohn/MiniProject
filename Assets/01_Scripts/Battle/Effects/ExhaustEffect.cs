using UnityEngine;

// 카드 소멸 효과
public class ExhaustEffect : IEffectBase
{
    [SerializeField] private GameObject card;

    public IEffectAction Set(Character source, Character target)
    {
        return new ExhaustCardAction(source, target, card);
    }

}
