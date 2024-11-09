using System;
using System.Collections;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public float baseDamageAmount = 10f; // Base damage amount (before any multipliers)
    public float attackRange = 2f; // Range to detect enemies
    public float damageAngle = 45f; // Angle range within which enemies are damaged

    public Animator weaponAnimator;
    public float delay = 1f;
    private bool attackBlocked;

    public AudioSource Audio;
    public AudioClip weaponSwing, weaponHit;

    private float currentDamageAmount;

    private void Start()
    {
        currentDamageAmount = baseDamageAmount; // Initialize current damage to base value
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + 2);

        Vector2 scale = transform.localScale;
        scale.y = difference.x < 0 ? -1 : 1;
        transform.localScale = scale;

        // Optionally call the damage function (e.g., when the player attacks)
        if (Input.GetMouseButtonDown(0)) // Replace with your attack trigger logic
        {
            Attack();
            DamageEnemiesInDirection(difference);
        }
    }

    private void DamageEnemiesInDirection(Vector2 direction)
    {
        // Get all enemies within a certain range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy")) // Ensure only enemies are considered
            {
                Vector2 toEnemy = (hitCollider.transform.position - transform.position).normalized;
                float angleToEnemy = Vector2.Angle(direction, toEnemy);

                if (angleToEnemy <= damageAngle)
                {
                    // Damage the enemy if it is within the allowed angle range
                    var enemyHealth = hitCollider.GetComponent<HealthController>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(currentDamageAmount);
                    }
                }
            }
        }
    }

    // Method to apply the damage multiplier
    public void ApplyDamageMultiplier(float multiplier)
    {
        currentDamageAmount = baseDamageAmount * multiplier;
    }

    // Method to reset the damage multiplier
    public void ResetDamageMultiplier()
    {
        currentDamageAmount = baseDamageAmount;
    }

    public void Attack() {
        if (attackBlocked) {
            return;
        }
        weaponAnimator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
