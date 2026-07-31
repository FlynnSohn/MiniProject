using UnityEngine;

public class Player : Character
{
    private EnergySystem energySystem;
    // protected int maxEnergy;


    public void Init(RunState state)
    {
        int playerCurrentHp = Mathf.Clamp(state.CurrentHp, 0, state.MaxHp);
        InitStats(state.MaxHp, playerCurrentHp);
        energySystem = new EnergySystem(3);

    }


    public override void Die()
    {
        //base.Die();
    }
}
