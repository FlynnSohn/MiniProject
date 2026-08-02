using UnityEngine;


public static class DefendCalculator
{
    public static int Calculate(Character receiver, int baseDefend)
    {
        // 방어카드를 낼 때 반영될 건 민첩뿐인듯
        // 그래도 일단 둘다 더해두긴 할까
        int sum = receiver.SumDefendGainedBonus();
        float scale = receiver.TotalDefendGainedMultiplier();
        return Mathf.FloorToInt((baseDefend + sum) * scale);
    }

}
