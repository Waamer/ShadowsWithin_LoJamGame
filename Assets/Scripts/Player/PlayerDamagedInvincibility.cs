using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibiltyDuration;

    private InvincibilityController _invincibiltyController;

    private void Awake() {
        _invincibiltyController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility() {
        _invincibiltyController.StartInvincibility(_invincibiltyDuration);
    }
    
}
