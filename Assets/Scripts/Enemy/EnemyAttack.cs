using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    [SerializeField]
    private float _damageAmount;

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<PlayerMovement>()) {
            var healthController = collision.gameObject.GetComponent<HealthController>();

            healthController.TakeDamage(_damageAmount);
        }
    }

}
