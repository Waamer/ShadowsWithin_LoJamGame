using TMPro;
using UnityEngine;
using UnityEngine.UI;  // If you're using the default Unity UI system (Text)

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesRemainingText; // Reference to a UI Text element (use TMP_Text for TextMesh Pro)
    [SerializeField] private int remainingEnemies = 21;

    // This method will be called to update the UI whenever an enemy is killed or spawned
    public void UpdateEnemyCount(int newCount)
    {
        remainingEnemies = newCount;
        enemiesRemainingText.text =  remainingEnemies.ToString() + " Enemies Left";
    }

    // Called when an enemy is spawned
    public void IncrementEnemyCount()
    {
        remainingEnemies++;
        UpdateEnemyCount(remainingEnemies);
    }

    // Called when an enemy is killed
    public void DecrementEnemyCount()
    {
        remainingEnemies--;
        UpdateEnemyCount(remainingEnemies);
    }
}
