//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragHandler : MonoBehaviour
{

    [SerializeField] private TurnManager turnManager;
    [SerializeField] private HandView handView;
    [SerializeField] private Camera cam;
    [SerializeField] private int dragSortingOrder = 1000;
    [SerializeField] private float playThresholdY = -2f;

    private BattleContext ctx;
    private CardView draggingView;

    // 카드 원점을 기준으로 어디를 잡았는지 저장하는 벡터
    private Vector3 grabOffset;

    public void Begin(BattleContext ctx) => this.ctx = ctx;
    void Awake()
    {
        if (cam == null) cam = Camera.main;
    }


    void Update()
    {
        if (ctx == null) return;

        Mouse mouse = Mouse.current;

        if (mouse.leftButton.wasPressedThisFrame) TryGrab();
        else if (mouse.leftButton.isPressed && draggingView != null) Drag();
        else if (mouse.leftButton.wasReleasedThisFrame && draggingView != null) Drop();

    }

    private Vector3 MouseWorldPos()
    {
        Vector3 p = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        p.z = 0f;
        return p;
    }

    /// <summary>
    /// 플레이할 카드 선택
    /// </summary>
    private void TryGrab()
    {
        Vector3 mouse = MouseWorldPos();
        CardView top = null;
        int topOrder = int.MinValue;

        // 어떤 카드가 제일 위에 있는지 검사해서 그 1장을 top에 할당하기 위함
        foreach (Collider2D col in Physics2D.OverlapPointAll(mouse))
        {
            CardView view = col.GetComponent<CardView>();
            if (view == null) continue;
            // 겹쳐 있을 시 위에 있는 것 선택
            if (view.SortingOrder <= topOrder) continue;
            topOrder = view.SortingOrder;
            top = view;
        }
        if (top == null) return;

        draggingView = top;
        grabOffset = draggingView.transform.position - mouse;
        draggingView.SetSortingOrder(dragSortingOrder);

    }
    // 드래그 중인 카드뷰의 실시간 포지션
    private void Drag() => draggingView.transform.position = MouseWorldPos() + grabOffset;

    private void Drop()
    {
        Card card = draggingView.Card;
        Vector3 mouse = MouseWorldPos();
        draggingView = null;

        Character target = card.NeedsTarget ? FindMonsterAt(mouse) : null;
        bool droppedValid = card.NeedsTarget ? target != null : mouse.y > playThresholdY;

        if (droppedValid) turnManager.PlayCard(card, target);

        // 남은 카드 재배치, 카드 플레이 안됐을시 제자리복귀
        handView.Layout();
    }

    /// <summary>
    /// 드래그 범위에서 겹치는 몬스터 전체 충돌 검사 후 해당 몬스터 하나 반환, 없으면 null 
    /// </summary>
    /// <param name="world"></param>
    /// <returns></returns>
    private Character FindMonsterAt(Vector3 world)
    {
        foreach (Collider2D col in Physics2D.OverlapPointAll(world))
        {
            Monster monster = col.GetComponent<Monster>();
            if (monster != null && !monster.IsDead) return monster;
        }
        return null;
    }
}
