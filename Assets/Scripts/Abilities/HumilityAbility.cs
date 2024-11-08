using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumilityAbility : MonoBehaviour
{
    [SerializeField] private float _currentCooldown = 0f;
    [SerializeField] private float _maximumCooldown = 4f;
    [SerializeField] private float _dodgeDuration = 0.1f;
    [SerializeField] private float _speedMultiplier = 5f;

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
        if (Keyboard.current.bKey.wasPressedThisFrame && !_isOnCooldown)
        {
            StartCoroutine(ActivateHumilityAbility());
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

    private IEnumerator ActivateHumilityAbility()
    {
        _playerMovement.SetSpeedMultiplier(_speedMultiplier);
        _isOnCooldown = true;
        _currentCooldown = _maximumCooldown;

        yield return new WaitForSeconds(_dodgeDuration);

        _playerMovement.SetSpeedMultiplier(1f);
    }
}

