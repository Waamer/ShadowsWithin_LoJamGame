using UnityEngine;
using UnityEngine.UI;

public class MotivationAbilityUI : MonoBehaviour
{
    [SerializeField] private Image _motivationCoverImg;
    [SerializeField] private MotivationAbility _motivationAbility;

    private void Update()
    {
        _motivationCoverImg.fillAmount = _motivationAbility.RemainingCooldownPercentage;
    }
}
