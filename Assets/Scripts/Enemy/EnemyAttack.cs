using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player; // Player GameObject reference
    public float speed = 3f;
    private float distance;
    private Vector2 direction;

    [SerializeField]
    private float _damageAmount;

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 playerPosition = player.transform.position;
            direction = (playerPosition - (Vector2)transform.position).normalized;

            transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(_damageAmount);
            }
        }
    }
}
