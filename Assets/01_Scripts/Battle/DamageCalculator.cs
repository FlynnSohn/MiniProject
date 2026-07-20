
using UnityEngine;

public static class DamageCalculator
{
    /// <summary>
    /// 상태이상 순회하며 상태이상 적용 후의 데미지 계산
    /// </summary>
    public static int Calculate(Character source, Character target, int baseDamage)
    {
        // 이걸 이제 소스가 타겟을 공격할 때 발동하는데, 
        // 이 때 TargetScope가 self냐 아니냐에 따라
        // source와 target는 동일할 수도 다를 수도 있다.

        // 흠... 공격이 하나 이루어진다고 가정했을 때,
        // 일단 대상이 self인지 아닌지에 따라 적용되는 상태이상 요소가 달라야 하겠다.
        // 왜냐하면 내가 패널티 카드를 쓸 때에도 DamageDealt scope self가 이루어지는데,
        // 이 때는 내가 가진 힘, 취약 등이 반영될 필요가 없기 때문이다.
        // 근데 방어카드 쓸 때 민첩같은 건 반영되어야 함... 

        // 잠깐 공격 받을때도 여기서 계산함.

        // 어쨌든 데미지 반영이 1번 이루어질 때 1번씩 호출되니까, 1번 호출할 때
        // 공격자(source)가 공격할 때 공격자의 가하는 공격량(damageDealt)가 더하기=>곱하기 순으로
        // 호출되고,
        // 타겟은 DamageReceived가 더하기-> 곱하기 순으로 호출된다.

        // 그래서 공격 데미지량은 베이스데미지에
        // 소스의 공격 힘+- 보너스랑 타겟의 민첩 감소/증가량 보너스를 더하고, 
        // 흠... 만약 내 약화가 0.75 있고, 상대의 취약이 1.5 있다면 총 배율은? 에휴 
        // 1.125가 되는게 맞는진 모르겠는데 어쨌든 맞는 게 더 쎄게 맞게 되는거니까 값이 대강 그럴듯한듯
        // 베이스데미지에 보너스 더한 뒤 거기에 1.125 곱하기 하면 됨 그리고 소수점은 내림하자

        if (source == target)
        {
            return baseDamage;
        }
        else
        {
            int sum = source.SumDamageDealtBonus() + target.SumDamageReceivedBonus();
            float scale = source.TotalDamageDealtMultiplier() * target.TotalDamageReceivedMultiplier();
            return Mathf.FloorToInt((baseDamage + sum) * scale);
        }

    }
}
