
public class VulnerableStatus : StatusEffectBase
{
    // 취약: X턴 동안 공격 카드를 통해 받는 피해량이 50% 증가합니다.
    // amount: 취약 수
    public override StatusType Type => StatusType.Vulnerable;
    public VulnerableStatus(int amount)
    {
        Stack = amount;
    }
    //public override int ChangeDamageReceived(int dmg) => (int)(dmg * 1.5f);
    public override float GetDamageReceivedMultiplier() => 1.5f;
    public override void OnTurnStart(Character owner, BattleContext ctx)
    {
        Stack--;
        if (Stack <= 0) owner.RemoveStatus(this);
    }
}
