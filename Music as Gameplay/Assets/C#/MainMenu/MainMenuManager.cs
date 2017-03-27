using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

  public Transform InitialMenu;
  public Transform CreditsMenu;
  public Transform OptionsMenu;
  public Transform PlayMenu;

  public Slider VolumeSlider;

  public Toggle FadeToggle;
  public Toggle ShootingStarsToggle;

  public AudioSource FadeMusic;
  public AudioSource InfectiusMusic;

  // Use this for initialization
  void Start ()
  {
    GameObject Manager = GameObject.Find("AudioManager");

    if (Manager == null)
      VolumeSlider.value = 1.0f;
    else
      VolumeSlider.value = AudioManager.GetInstance.GetVolume();

  }
	
	// Update is called once per frame
	void Update ()
  {
	
	}

  public void Play(int scene)
  {
    if (FadeToggle.isOn || ShootingStarsToggle.isOn)
    {
      SceneManager.LoadScene(scene);
    }
  }
  
  public void Exit()
  {
    Application.Quit();
  }

  public void BackFromCreditsMenu()
  {
    if (CreditsMenu.gameObject.activeInHierarchy)
    {
      InitialMenu.gameObject.SetActive(true);
      CreditsMenu.gameObject.SetActive(false);
    }
  }
  
  public void AviteCreditsMenu()
  {
    if (InitialMenu.gameObject.activeInHierarchy)
    {
      InitialMenu.gameObject.SetActive(false);
      CreditsMenu.gameObject.SetActive(true);
    }
  }

  public void BackFromOptionsMenu()
  {
    if (OptionsMenu.gameObject.activeInHierarchy)
    {
      InitialMenu.gameObject.SetActive(true);
      OptionsMenu.gameObject.SetActive(false);
    }
  }

  public void ActivateOptionsMenu()
  {
    if (InitialMenu.gameObject.activeInHierarchy)
    {
      InitialMenu.gameObject.SetActive(false);
      OptionsMenu.gameObject.SetActive(true);
    }
  }

  public void Volume()
  {
    AudioManager.GetInstance.SetVolume(VolumeSlider.value);
    InfectiusMusic.volume = VolumeSlider.value;
    FadeMusic.volume = VolumeSlider.value;
  }

  public void BackFromPlayMenu()
  {
    if (PlayMenu.gameObject.activeInHierarchy)
    {
      InitialMenu.gameObject.SetActive(true);
      PlayMenu.gameObject.SetActive(false);
    }
  }

  public void ActivatePlayMenu()
  {
    if (InitialMenu.gameObject.activeInHierarchy)
    {
      InitialMenu.gameObject.SetActive(false);
      PlayMenu.gameObject.SetActive(true);
      AudioManager.GetInstance.ResetVariables();
    }
  }

  public void FadeSongToggle()
  {
    if (FadeToggle.isOn)
    {
      AudioManager.GetInstance.SetSongs(2);
      ShootingStarsToggle.isOn = false;

      FadeMusic.Play();
      InfectiusMusic.Stop();
    }
    else
      FadeMusic.Stop();

  }

  public void ShootingStarsSongToggle()
  {
    if (ShootingStarsToggle.isOn)
    {
      AudioManager.GetInstance.SetSongs(1);
      FadeToggle.isOn = false;

      FadeMusic.Stop();
      InfectiusMusic.Play();
    }
    else
      InfectiusMusic.Stop();

  }

}
