using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {

  public Transform PauseMenu;
  public AudioSource MuteMusic;
  public AudioSource NoMuteMusic;

  // Use this for initialization
  void Start ()
  {
	
	}
	
	// Update is called once per frame
	void Update ()
  {
    ActivatePauseMenu();
	}

  void ActivatePauseMenu()
  {
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
    {
      if (!PauseMenu.gameObject.activeInHierarchy)
      {
        PauseMenu.gameObject.SetActive(true);
        MuteMusic.Pause();
        NoMuteMusic.Pause();
        Time.timeScale = 0;
      }
    }
  }

  public void DesactivatePauseMenu()
  {
    if (PauseMenu.gameObject.activeInHierarchy)
    {
      PauseMenu.gameObject.SetActive(false);
      MuteMusic.UnPause();
      NoMuteMusic.UnPause();
      Time.timeScale = 1;
    }
  }

  public void GoMainMenu(int scene)
  {
    SceneManager.LoadScene(scene);
  }
}
