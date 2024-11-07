using System.Collections;
using UnityEngine;

public class RegenerationController : MonoBehaviour
{
    [SerializeField]
    private float _regenerationAmountPerSecond; // Amount of health to regenerate per second

    [SerializeField]
    private float _regenerationDelay; // Time to wait after taking damage before starting regeneration

    private HealthController _healthController;
    private Coroutine _regenerationCoroutine;

    private void Awake() {
        _healthController = GetComponent<HealthController>();
    }

    public void StartRegeneration() {
        if (_regenerationCoroutine != null) {
            StopCoroutine(_regenerationCoroutine);
        }
        _regenerationCoroutine = StartCoroutine(RegenerationCoroutine());
    }

    private IEnumerator RegenerationCoroutine() {
        yield return new WaitForSeconds(_regenerationDelay);

        while (_healthController.RemainingHealthPercentage < 1.0f) {
            _healthController.AddHealth(_regenerationAmountPerSecond * Time.deltaTime);
            yield return null;
        }
    }
}
