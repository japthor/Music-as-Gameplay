using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {

  public Transform PauseMenu;
  public Transform OptionsMenu;
  public AudioSource BackGroundMusic;
  public AudioSource ObjectsMusic;
  public Slider VolumeSlider;

  // Use this for initialization
  void Start ()
  {
    VolumeSlider.value = AudioManager.GetInstance.GetVolume();
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      ActivatePauseMenu();
    }
	}

  void ActivatePauseMenu()
  {
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
    {
      if (!PauseMenu.gameObject.activeInHierarchy)
      {
        PauseMenu.gameObject.SetActive(true);
        BackGroundMusic.Pause();
        ObjectsMusic.Pause();
        AudioManager.GetInstance.SetIsPaused(true);
      }
    }
  }

  public void DesactivatePauseMenu()
  {
    if (PauseMenu.gameObject.activeInHierarchy)
    {
      PauseMenu.gameObject.SetActive(false);
      BackGroundMusic.UnPause();
      ObjectsMusic.UnPause();
      AudioManager.GetInstance.SetIsPaused(false);
    }
  }

  public void GoMainMenu(int scene)
  {
    SceneManager.LoadScene(scene);
    AudioManager.GetInstance.ResetVariables();
  }

  public void ActivateOptionsMenu()
  {
    if (PauseMenu.gameObject.activeInHierarchy)
    { 
      PauseMenu.gameObject.SetActive(false);
      OptionsMenu.gameObject.SetActive(true);
    }
  }

  public void DesactivateOptionsMenu()
  {
    if (OptionsMenu.gameObject.activeInHierarchy)
    {
      OptionsMenu.gameObject.SetActive(false);
      PauseMenu.gameObject.SetActive(true);
    }
  }

  public void Volume()
  {
    BackGroundMusic.volume = VolumeSlider.value;
    AudioManager.GetInstance.SetVolume(BackGroundMusic.volume);
  }
}
