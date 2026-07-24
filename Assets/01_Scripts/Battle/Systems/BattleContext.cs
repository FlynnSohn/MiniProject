using System.Collections.Generic;
using UnityEngine;

public class BattleContext : MonoBehaviour
{
    [SerializeField] private int energy;
    private Deck deck; // 현재 보유 중인 카드 데이터(마스터)를 복사해 저장
    private List<Card> drawDeckPile;
    private List<Card> shuffle; // 카드 섞어서 draw에 넣기용
    private List<Card> exhaustDeckPile; // 소멸 순 정렬
    private List<Card> discardDeckPile; // 버린 순 정렬
    private List<Card> hand; // 손패

    [SerializeField] private ActionQueue actionQueue; // 카드 임의로 뽑아오는 기능은 없다고 가정


    void Start()
    {

    }


    void Update()
    {

    }
}
