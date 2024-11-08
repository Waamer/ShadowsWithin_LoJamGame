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
        // Make sure the player is assigned
        if (player != null)
        {
            // Get the current position of the player
            Vector2 playerPosition = player.transform.position;

            // Calculate the direction from enemy to player
            direction = (playerPosition - (Vector2)transform.position).normalized;

            // Move the enemy towards the player
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
