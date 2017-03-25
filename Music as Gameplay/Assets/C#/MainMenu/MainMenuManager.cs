using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

  public Transform InitialMenu;
  public Transform CreditsMenu;
  public Transform OptionsMenu;
  public Slider VolumeSlider;
  public AudioSource BackGroundMusic;

  // Use this for initialization
  void Start ()
  {
	
	}
	
	// Update is called once per frame
	void Update ()
  {
	
	}

  public void Play(int scene)
  {
    SceneManager.LoadScene(scene);
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
    BackGroundMusic.volume = VolumeSlider.value;
    AudioManager.GetInstance.SetVolume(BackGroundMusic.volume);
  }

}
