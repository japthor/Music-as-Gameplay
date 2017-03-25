using UnityEngine;
using System.Collections;

public class AudioPlayMusic : MonoBehaviour {

  private float SecondsToStartMusic;
  private AudioSource AudioSource;
  private bool Play;

  // Use this for initialization
  void Start ()
  {
    SecondsToStartMusic = 3.0f;
    AudioSource = GetComponent<AudioSource>();
    Play = false;
    
    if(gameObject.tag == "BackGroundMusic")
      AudioSource.volume = AudioManager.GetInstance.GetVolume();
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
      PlayMusic();
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
}
