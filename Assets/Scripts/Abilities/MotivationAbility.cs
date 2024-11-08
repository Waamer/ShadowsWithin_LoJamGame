using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MotivationAbility : MonoBehaviour
{
    [SerializeField] private float _currentCooldown = 0f;
    [SerializeField] private float _maximumCooldown = 8f;
    [SerializeField] private float _boostDuration = 3f;
    [SerializeField] private float _speedMultiplier = 2f;

    private bool _isOnCooldown = false;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public float RemainingCooldownPercentage
    {
        get { return _currentCooldown / _maximumCooldown; }
    }

    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame && !_isOnCooldown)
        {
            StartCoroutine(ActivateMotivationAbility());
        }

        if (_isOnCooldown)
        {
            _currentCooldown -= Time.deltaTime;
            if (_currentCooldown <= 0)
            {
                _currentCooldown = 0;
                _isOnCooldown = false;
            }
        }
    }

    private IEnumerator ActivateMotivationAbility()
    {
        _playerMovement.SetSpeedMultiplier(_speedMultiplier);
        _isOnCooldown = true;
        _currentCooldown = _maximumCooldown;

        yield return new WaitForSeconds(_boostDuration);

        _playerMovement.SetSpeedMultiplier(1f);
    }
}
