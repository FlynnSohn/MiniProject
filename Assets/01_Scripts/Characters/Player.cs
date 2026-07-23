using UnityEngine;

public class Player : Character
{

    protected int maxEnergy;


    // void Awake()
    // {

    // }
    // void Start()
    // {

    // }
    public void Init(RunState state)
    {
        int playerCurrentHp = Mathf.Clamp(state.CurrentHp, 0, state.MaxHp);
        InitStats(state.MaxHp, playerCurrentHp);
        maxEnergy = 3;
        currentEnergy = maxEnergy;

    }


    public override void Die()
    {
        //base.Die();
    }
}
