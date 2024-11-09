using System;
using System.Collections;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public float baseDamageAmount = 10f;
    public float attackRange = 2f;
    public float damageAngle = 45f;

    public Animator weaponAnimator;
    public float delay = 1f;
    private bool attackBlocked;

    public AudioSource Audio;
    public AudioClip weaponSwing, weaponHit;

    private float currentDamageAmount;

    private void Start()
    {
        currentDamageAmount = baseDamageAmount;
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

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            DamageEnemiesInDirection(difference);
        }
    }

    private void DamageEnemiesInDirection(Vector2 direction)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Vector2 toEnemy = (hitCollider.transform.position - transform.position).normalized;
                float angleToEnemy = Vector2.Angle(direction, toEnemy);

                if (angleToEnemy <= damageAngle)
                {
                    var enemyHealth = hitCollider.GetComponent<HealthController>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(currentDamageAmount);
                    }
                }
            }
        }
    }

    public void ApplyDamageMultiplier(float multiplier)
    {
        currentDamageAmount = baseDamageAmount * multiplier;
    }

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
