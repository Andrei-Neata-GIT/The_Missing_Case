using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string gameSceneName = "Game";

    public AudioSource menuMusic;

    public void PlayIntro()
    {
        // Stop main menu music
        if (menuMusic != null)
            menuMusic.Stop();

        // Start video
        videoPlayer.Play();
        videoPlayer.loopPointReached += VideoFinished;
    }

    private void VideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(gameSceneName);
    }
}