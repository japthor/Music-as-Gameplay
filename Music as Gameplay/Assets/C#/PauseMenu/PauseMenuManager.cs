using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {

  public Transform[] Menus = new Transform[3];
  public AudioSource[] Music = new AudioSource[2];
  public Slider VolumeSlider;
  public Text FinalScore;


  void Start ()
  {
    VolumeSlider.value = AudioManager.GetInstance.GetVolume;
  }
	

	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused)
      ActivatePauseMenu();

    if (AudioManager.GetInstance.GetIsGameFinished)
    {
      AudioManager.GetInstance.GetIsPaused = true;
      Menus[2].gameObject.SetActive(true);
      FinalScore.text = AudioManager.GetInstance.GetScore.ToString() + " Points";
    }
	}

  public void GoMainMenu(int scene)
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(scene);
  }

  void ActivatePauseMenu()
  {
    if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !AudioManager.GetInstance.GetIsGameFinished)
    {
      if (!Menus[0].gameObject.activeInHierarchy)
        PauseMenu(true);
    }
  }

  public void DesactivatePauseMenu()
  {
    if (Menus[0].gameObject.activeInHierarchy)
      PauseMenu(false);
  }

  void PauseMenu(bool active)
  {
    Menus[0].gameObject.SetActive(active);

    if (active)
    {
      PauseMusic(active);
      AudioManager.GetInstance.GetIsPaused = active;
      Time.timeScale = 0;
    }
    else
    {
      PauseMusic(active);
      AudioManager.GetInstance.GetIsPaused = active;
      Time.timeScale = 1;
    }
  }

  void PauseMusic(bool result)
  {
    if (result)
    {
      Music[0].Pause();
      Music[1].Pause();
    }
    else
    {
      Music[0].UnPause();
      Music[1].UnPause();
    }
  }


  public void ActivateOptionsMenu()
  {
    MoveMenu(Menus[0], Menus[1]);
  }

  public void DesactivateOptionsMenu()
  {
    MoveMenu(Menus[1], Menus[0]);
  }

  void MoveMenu(Transform from, Transform to)
  {
    if (from.gameObject.activeInHierarchy)
    {
      to.gameObject.SetActive(true);
      from.gameObject.SetActive(false);
    }
  }

  public void Volume()
  {
    Music[0].volume = VolumeSlider.value;
    AudioManager.GetInstance.GetVolume = Music[0].volume;
  }
}
