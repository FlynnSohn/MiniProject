using UnityEngine;


public class Player : Character
{
    //[SerializeField] TextMeshProUGUI hpText;
    // protected int maxEnergy;

    public void Init(RunState state)
    {
        int playerCurrentHp = Mathf.Clamp(state.CurrentHp, 0, state.MaxHp);
        InitStats(state.MaxHp, playerCurrentHp);

    }


    public override void Die()
    {
        //base.Die();
    }
}
