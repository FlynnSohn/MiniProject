
using System;

public class EnergySystem
{
    public int CurrentEnergy { get; private set; }
    public int EnergyPerTurn { get; private set; }
    public event Action OnChanged;

    // 에너지는 체력이랑 달리 Max값 바깥까지 소유할 수 있는데 이름을 바꿀까
    public EnergySystem(int e)
    {
        EnergyPerTurn = e;
        CurrentEnergy = EnergyPerTurn;
    }

    public bool CanAfford(int cost) => cost >= 0 && CurrentEnergy >= cost;

    public void Spend(int cost)
    {
        if (cost < 0) return;

        CurrentEnergy -= cost;
        OnChanged?.Invoke();
    }
    public void GainEnergy(int energy)
    {
        CurrentEnergy += energy;
        OnChanged?.Invoke();
    }
    public void ResetToDefault()
    {
        CurrentEnergy = EnergyPerTurn;
        OnChanged?.Invoke();
    }
}
