using System.Collections.Generic;


public class ActionQueue
{
    private readonly LinkedList<IEffectAction> queue = new();


    private bool isRunning;

    public void PushFront(IEffectAction a)
    {
        queue.AddFirst(a);
    }
    public void PushBack(IEffectAction b)
    {
        queue.AddLast(b);
    }
    public void RunAll(BattleContext ctx)
    {
        if (isRunning) return;
        int loopGuard = 0;
        LinkedListNode<IEffectAction> firstAction;
        IEffectAction action;

        isRunning = true;
        while (queue.Count != 0)
        {
            firstAction = queue.First;
            action = firstAction.Value;
            queue.RemoveFirst();
            action.Execute(ctx);


            loopGuard++;

            if (loopGuard >= 1000)
            {
                queue.Clear();
                UnityEngine.Debug.LogError("큐순환무한반복중");
                break;
            }
        }
        ctx.Enemies.DoDie();
        isRunning = false;
    }
}
