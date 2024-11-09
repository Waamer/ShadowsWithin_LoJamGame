using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader; 
    
    public void PlayGame() {
        if (levelLoader != null) {
            levelLoader.LoadNextLevel();  
        }
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
    

}
