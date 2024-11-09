using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    [SerializeField] Animator UItransition;


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        if(UItransition != null) {
                    UItransition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

}
