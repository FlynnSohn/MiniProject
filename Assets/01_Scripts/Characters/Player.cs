using UnityEngine;

public class Player : Character
{
    [SerializeField] protected int maxHp;
    protected int maxEnergy;

    void Awake()
    {
        maxEnergy = 3;
        currentHp = maxHp;
        currentDefend = 0;
    }
    void Start()
    {

    }


    public override void Die()
    {
        //base.Die();
    }
}
