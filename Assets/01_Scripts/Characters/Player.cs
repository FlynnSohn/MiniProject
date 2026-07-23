using UnityEngine;

public class Player : Character
{

    protected int maxEnergy;

    void Awake()
    {
        maxHp = 80;
        maxEnergy = 3;
        currentHp = maxHp;
        currentEnergy = maxEnergy;
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
