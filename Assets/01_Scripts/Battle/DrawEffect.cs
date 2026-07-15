using UnityEngine;
using System;


[Serializable]
public class DrawEffect : IEffectBase
{
    [SerializeField] private int draw;
    public IEffectAction Set(Character source, Character target)
    {
        return new DrawCardAction(source, target, draw);
    }
}
