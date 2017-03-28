using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {

  public Transform PauseMenu;
  public Transform OptionsMenu;
  public Transform GameOverMenu;
  public AudioSource BackGroundMusic;
  public AudioSource ObjectsMusic;
  public Slider VolumeSlider;
  public Text FinalScore;

  // Use this for initialization
  void Start ()
  {
    VolumeSlider.value = AudioManager.GetInstance.GetVolume();
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
      ActivatePauseMenu();

    if (AudioManager.GetInstance.GetIsGameFinished())
    {
      AudioManager.GetInstance.SetIsPaused(true);
      GameOverMenu.gameObject.SetActive(true);
      FinalScore.text = AudioManager.GetInstance.GetScore().ToString() + " Points";
    }
	}

  void ActivatePauseMenu()
  {
    if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !AudioManager.GetInstance.GetIsGameFinished())
    {
      if (!PauseMenu.gameObject.activeInHierarchy)
      {
        PauseMenu.gameObject.SetActive(true);
        BackGroundMusic.Pause();
        ObjectsMusic.Pause();
        AudioManager.GetInstance.SetIsPaused(true);
        Time.timeScale = 0;
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
      Time.timeScale = 1;
    }
  }

  public void GoMainMenu(int scene)
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(scene);
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
