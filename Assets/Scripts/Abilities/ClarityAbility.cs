using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ClarityAbility : MonoBehaviour
{
    [SerializeField] private float _currentCooldown = 0f;
    [SerializeField] private float _maximumCooldown = 8f;
    [SerializeField] private float _damageIncreaseDuration = 2f;
    [SerializeField] private float _damageMultiplier = 2f;

    private bool _isOnCooldown = false;

    private WeaponParent _weaponParent; // Reference to the WeaponParent script

    private void Awake()
    {
        _weaponParent = GetComponent<WeaponParent>(); // Assuming WeaponParent is attached to the same GameObject
    }

    public float RemainingCooldownPercentage
    {
        get { return _currentCooldown / _maximumCooldown; }
    }

    void Update()
    {
        if (Keyboard.current.vKey.wasPressedThisFrame && !_isOnCooldown)
        {
            StartCoroutine(ActivateClarityAbility());
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

    private IEnumerator ActivateClarityAbility()
    {
        // Apply damage multiplier
        if (_weaponParent != null)
        {
            _weaponParent.ApplyDamageMultiplier(_damageMultiplier);
        }

        _isOnCooldown = true;
        _currentCooldown = _maximumCooldown;

        // Wait for the duration of the Clarity ability
        yield return new WaitForSeconds(_damageIncreaseDuration);

        // Reset damage multiplier
        if (_weaponParent != null)
        {
            _weaponParent.ResetDamageMultiplier();
        }
    }
}
