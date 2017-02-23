using UnityEngine;
using System.Collections;

public class AudioPlayNoMuteMusic : MonoBehaviour {

  public float SecondsToStartMusic;
  AudioSource AudioSource;
  bool Play;
  // Use this for initialization
  void Start () {
    AudioSource = GetComponent<AudioSource>();
    Play = false;
  }
	
	// Update is called once per frame
	void Update () {

    if (SecondsToStartMusic <= 0.0f)
    {
      if (!Play)
      {
        AudioSource.Play();
        Play = true;
      }
    }
    else
    {
      SecondsToStartMusic -= Time.deltaTime;
    }
  }
}
