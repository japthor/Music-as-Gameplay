using UnityEngine;
using System.Collections;

public class AudioMusic : MonoBehaviour {

  private AudioSource AudioSource;

  private float SecondsToStartMusic;
  private float SecondsToFinishMusic;
  private bool Play;

  // Use this for initialization
  void Start ()
  {
    AudioSource = GetComponent<AudioSource>();

    SecondsToStartMusic = 3.0f;
    SecondsToFinishMusic = SecondsToStartMusic * 2.0f;
    Play = false;

    switch (AudioManager.GetInstance.GetSongs)
    {
      case 1:
        AudioSource.clip = Resources.Load("Tobu - Infectious") as AudioClip;
        break;

      case 2:
        AudioSource.clip = Resources.Load("Alan Walker - Fade") as AudioClip;
        break;

      case 3:
        AudioSource.clip = Resources.Load("Tobu - Seven") as AudioClip;
        break;

      default:
        break;
    }

    if (gameObject.tag == "BackGroundMusic")
      AudioSource.volume = AudioManager.GetInstance.GetVolume;
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused)
    {
      PlayMusic();
      ActivePowerUp();
      EndMusic();
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

  void EndMusic()
  {
    if (!AudioSource.isPlaying && Play)
    {
      if (SecondsToFinishMusic <= 0.0f)
        AudioManager.GetInstance.GetIsGameFinished = true;
      else
        SecondsToFinishMusic -= Time.deltaTime;
    }
  }

  void ActivePowerUp()
  {
    if (AudioManager.GetInstance.GetIsActivePowerUp)
    {
      if (AudioManager.GetInstance.GetPowerUpTime <= 0.0f)
      {
        Time.timeScale = 1.0f;
        AudioManager.GetInstance.GetIsActivePowerUp = false;
      }
      else
      {
        AudioSource.pitch = 0.5f;
        Time.timeScale = 0.5f;
        AudioManager.GetInstance.GetPowerUpTime = AudioManager.GetInstance.GetPowerUpTime - Time.deltaTime;
      }
    }
    else
    {
      if(AudioSource.pitch != 1.0f)
        AudioSource.pitch = 1.0f;
    }
  }
}
