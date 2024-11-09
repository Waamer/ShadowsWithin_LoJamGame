using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] scriptsToDisable;

    private void OnEnable()
    {
        Dialogue.OnDialogueStart += DisableScripts;
        Dialogue.OnDialogueEnd += EnableScripts;
    }

    private void OnDisable()
    {
        Dialogue.OnDialogueStart -= DisableScripts;
        Dialogue.OnDialogueEnd -= EnableScripts;
    }

    private void DisableScripts()
    {
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }
    }

    private void EnableScripts()
    {
        foreach (var script in scriptsToDisable)
        {
            script.enabled = true;
        }
    }
}
