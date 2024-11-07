using System.Collections;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{

    private HealthController _healthController;

    private void Awake() {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float invincibilityDuration) {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration) {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _healthController.IsInvincible = false;
    }
    
}
