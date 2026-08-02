using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI drawCountText;
    [SerializeField] private TextMeshProUGUI discardCountText;
    [SerializeField] private TextMeshProUGUI exhaustCountText;
    [SerializeField] private TextMeshProUGUI goldText;

    private EnergySystem energy;
    private CardPiles cardPiles;

    public void Begin(BattleContext ctx)
    {
        energy = ctx.Energy;
        cardPiles = ctx.CardPiles;

        energy.OnChanged += RefreshEnergy;
        cardPiles.OnPilesChanged += RefreshPiles;

        RefreshEnergy();
        RefreshPiles();
        goldText.text = GameManager.instance.Run.Gold.ToString();
    }

    private void OnDestroy()
    {
        if (energy != null) energy.OnChanged -= RefreshEnergy;
        if (cardPiles != null) cardPiles.OnPilesChanged -= RefreshPiles;
    }

    private void RefreshEnergy() => energyText.text = energy.CurrentEnergy.ToString();
    private void RefreshPiles()
    {
        drawCountText.text = cardPiles.DrawCount.ToString();
        discardCountText.text = cardPiles.DiscardCount.ToString();
        exhaustCountText.text = cardPiles.ExhaustCount.ToString();
    }

}
