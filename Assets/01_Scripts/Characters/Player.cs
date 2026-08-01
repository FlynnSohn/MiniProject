using UnityEngine;
using TMPro;

public class Player : Character
{
    //[SerializeField] TextMeshProUGUI hpText;
    // protected int maxEnergy;
    void Awake()
    {
        OnStatsChanged += RefreshHpText;
    }

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
