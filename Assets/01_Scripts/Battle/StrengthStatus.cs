

public class StrengthStatus : StatusEffectBase
{
    // 데미지 계산할 때 특정 값만큼 증감

    public StrengthStatus(int amount)
    {
        Stack = amount;
    }
    public override int ChangeDamageDealing(int dmg) => dmg + Stack;

}
