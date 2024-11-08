using UnityEngine;
using UnityEngine.UI;

public class HumilityAbilityUI : MonoBehaviour
{
    [SerializeField] private Image _humilityCoverImg;
    [SerializeField] private HumilityAbility _humilityAbility;

    private void Update()
    {
        _humilityCoverImg.fillAmount = _humilityAbility.RemainingCooldownPercentage;
    }
}
