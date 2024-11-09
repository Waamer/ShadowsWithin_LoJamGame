using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesRemainingText;

    public void UpdateEnemyCount(int newCount)
    {
        enemiesRemainingText.text = newCount.ToString() + " Enemies Left";
    }
}
