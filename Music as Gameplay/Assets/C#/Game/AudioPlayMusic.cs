using UnityEngine;
using System.Collections;

public class AudioPlayMusic : MonoBehaviour {

  private float SecondsToStartMusic;
  private float SecondsToFinishGame;
  private AudioSource AudioSource;
  private bool Play;

  // Use this for initialization
  void Start ()
  {
    SecondsToStartMusic = 3.0f;
    SecondsToFinishGame = 6.0f;
    AudioSource = GetComponent<AudioSource>();
    Play = false;

    switch (AudioManager.GetInstance.GetSongs())
    {
      case 1:
        AudioSource.clip = Resources.Load("Tobu - Infectious") as AudioClip;
        break;

      case 2:
        AudioSource.clip = Resources.Load("Alan Walker - Fade") as AudioClip;
        break;

      default:
        break;
    }

    if (gameObject.tag == "BackGroundMusic")
      AudioSource.volume = AudioManager.GetInstance.GetVolume();
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      PlayMusic();
      EndGame();
    }
  }

  void PlayMusic()
  {
    if (SecondsToStartMusic <= 0.0f)
    {
      if (!Play)
      {
        AudioSource.Play();
        Play = true;
      }
    }
    else
      SecondsToStartMusic -= Time.deltaTime;
  }

  void EndGame()
  {
    if (!AudioSource.isPlaying && Play)
    {
      if (SecondsToFinishGame <= 0.0f)
        AudioManager.GetInstance.SetIsGameFinished(true);
      else
        SecondsToFinishGame -= Time.deltaTime;
    }
  }
}
