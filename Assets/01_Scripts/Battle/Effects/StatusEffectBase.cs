using UnityEngine;



public abstract class StatusEffectBase
{
    public int Stack { get; protected set; }
    public void AddStack(int amount) => Stack += amount;

    // 게임 내내 영구 적용 

    // 해당 전투 동안 영구 적용 -> 그냥 9999턴으로 고정하자.

    // 특정 턴 동안 카운트 1씩 감소해가며 적용

    // 특정 턴 동안 적용

    // 이번 턴 적용

    // 조건부 적용. ~할 때마다

    // 적용 시점에 Characters의 StatusEffects리스트에 추가하고 0되면 제거하기


    // 지속시간 있는 거
    public virtual void OnTurnStart(Character owner) { } // 중독 실행, 취약 카운트 감소 등
    public virtual void OnTurnEnd(Character owner) { } // 조건이 '이번 턴만'인 것들의 효과를 제거

    // 값을 더하고 빼는 거
    public virtual int ChangeDamageDealing(int dmg) => dmg; // 내 공격력에 영향주는거, 힘/약화
    public virtual int ChangeDamageReceived(int dmg) => dmg; // 더 쎄게맞는거 취약 vulnerable
    public virtual int ChangeDefendGained(int defend) => defend; // 민첩, 방어덜들어오는거

    // 조건부
    public virtual void OnCardExhausted(Character owner) { } // 카드 소멸 조건부 어둠의 포옹 등
    public virtual void OnOwnerAttacked(Character owner, Character attacker) { } // 반격
    public virtual void OnCardPlayed(CardData card, Character owner) { } // 격노, 카드를 사용할 때마다



    // 현재 존재하는 카드 조건들

    // 내 턴 시작 시 방어도가 사라지지 않습니다. // ?? 이건 턴 시작할 때 방어도 리셋하는 곳에 찾아가야 할 듯

    // 피해를 8 줍니다. 취약을 2 부여합니다. // Vulnerable 2

    // 체력을 3 잃습니다. 2 에너지를 얻습니다. 

    // 방어도만큼의 피해를 줍니다. // 방어도 받아오기

    // 카드를 1장 소멸시킵니다. 카드를 2장 뽑습니다. 

    // 카드가 소멸될 때마다, 카드를 1장 뽑습니다. // OnCardExhausted

    // 피해를 10 줍니다. 치명타라면, 최대 체력이 3 증가합니다. 소멸. 

    // 카드가 소멸될 떄마다, 방어도를 3 얻습니다.// OnCardExhausted

    // 방어도를 12 얻습니다. 이번 턴에 공격을 받을 때마다, 공격한 적에게 피해를 4 줍니다. // OnOwnerAttacked

    // 체력을 2 잃습니다. 피해를 15 줍니다.

    //방어도를 30 얻습니다. 소멸. 

    // 체력을 6 잃습니다. 에너지 2를 얻습니다. 카드를 3장 뽑습니다. 소멸.

    // 이번 턴에 공격 카드를 사용할 때마다, 방어도를 3 얻습니다. // attack 타입 카드 OnCardPlayed

    // 손에 있는 공격이 아닌 모든 카드를 소멸시킵니다. 소멸시킨 카드 1장당 방어도를 5 얻습니다. // attack 타입 외 손 카드 소멸 // OnCardExhausted

    // 방어도를 1 얻습니다. 카드를 1장 뽑습니다. 



}
