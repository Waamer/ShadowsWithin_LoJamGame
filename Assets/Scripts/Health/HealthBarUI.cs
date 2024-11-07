using UnityEngine;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImg;

    public void UpdateHealthBar(HealthController healthController) {
        _healthBarForegroundImg.fillAmount = healthController.RemainingHealthPercentage;
    }
    
}
