using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndingVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string mainMenuSceneName = "MainMenu";
    public GameObject enemyToDisable;

    public void PlayEndingVideo()
    {
        if (enemyToDisable != null)
            enemyToDisable.SetActive(false);

        videoPlayer.loopPointReached -= VideoFinished;
        videoPlayer.loopPointReached += VideoFinished;

        videoPlayer.Play();
    }

    private void VideoFinished(VideoPlayer vp)
    {
        // Unlock and show the mouse for the Main Menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Make sure the game isn't paused
        Time.timeScale = 1f;

        SceneManager.LoadScene(mainMenuSceneName);
    }
}