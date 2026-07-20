using UnityEngine;


public static class DefendCalculator
{
    public static int Calculate(Character source, Character target, int baseDefend)
    {
        // 난 모르겠네... 방어를 타겟이 받을 일이 있나? 그런 카드도 없고 몬스터 스킬도 없고
        // scope도 안 나눴고... 
        // 방어카드를 낼 때 반영될 건 민첩뿐인듯
        // 그래도 일단 둘다 더해두긴 할까
        int sum = source.SumDefendGainedBonus();
        float scale = source.TotalDefendGainedMultiplier();
        return Mathf.FloorToInt((baseDefend + sum) * scale);
    }

}
