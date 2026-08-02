using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject defendRoot;
    [SerializeField] private TextMeshProUGUI defendText;


    void Awake()
    {
        if (character == null) character = GetComponentInParent<Character>();
        if (character == null)
        {
            Debug.LogError($"{name}: 캐릭터를 못 찾음", this);
            return;
        }
        character.OnStatsChanged += Refresh;
    }


    private void OnDestroy()
    {
        if (character != null) character.OnStatsChanged -= Refresh;
    }

    public void SetName(string name) // Monster Init에서 호출
    {
        if (nameText != null) nameText.text = name;
    }

    /// <summary>
    /// 체력, 방어력 ui 갱신 함수
    /// </summary>
    private void Refresh()
    {
        hpText.text = $"{character.CurrentHp} / {character.MaxHp}";

        if (hpSlider != null)
        {
            hpSlider.value = character.MaxHp > 0
            ? (float)character.CurrentHp / character.MaxHp : 0f;
        }

        if (defendRoot != null) defendRoot.SetActive(character.CurrentDefend > 0);
        if (defendText != null) defendText.text = character.CurrentDefend.ToString();
    }
}
