using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

  public Transform InitialMenu;
  public Transform CreditsMenu;

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

}
