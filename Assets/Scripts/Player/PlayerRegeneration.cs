using UnityEngine;

public class PlayerRegeneration : MonoBehaviour
{
    private RegenerationController _regenerationController;

    private void Awake() {
        _regenerationController = GetComponent<RegenerationController>();
    }

    public void OnPlayerDamaged() {
        _regenerationController.StartRegeneration();
    }
}
