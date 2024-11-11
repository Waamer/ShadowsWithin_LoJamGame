using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class VideoSceneLoader : MonoBehaviour
{
    [SerializeField] string videoFileName;
    public VideoPlayer videoPlayer;
    public Animator transitionAnimator;

    void Start()
    {
        if (videoPlayer != null)
        {
            PlayVideo();
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    public void PlayVideo()
    {
        if (videoPlayer)
        {
            string videoPath = Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("Start");
        }

        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
