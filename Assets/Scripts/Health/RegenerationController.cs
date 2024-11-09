using System.Collections;
using UnityEngine;

public class RegenerationController : MonoBehaviour
{
    [SerializeField]
    private float _regenerationAmountPerSecond;

    [SerializeField]
    private float _regenerationDelay;

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
