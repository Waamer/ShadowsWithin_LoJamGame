using UnityEngine;
using UnityEngine.UI;

public class ClarityAbilityUI : MonoBehaviour
{
    [SerializeField] private Image _clarityCoverImg;
    [SerializeField] private ClarityAbility _clarityAbility;

    private void Update()
    {
        _clarityCoverImg.fillAmount = _clarityAbility.RemainingCooldownPercentage;
    }
}
