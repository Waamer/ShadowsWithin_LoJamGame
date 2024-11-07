using UnityEngine;

public class PlayerRegeneration : MonoBehaviour
{
    private RegenerationController _regenerationController;

    private void Awake() {
        _regenerationController = GetComponent<RegenerationController>();
    }

    // Call this when the player takes damage
    public void OnPlayerDamaged() {
        _regenerationController.StartRegeneration();
    }
}
