using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void Play(int scene)
  {
    SceneManager.LoadScene(scene);
  }
  
  public void Exit()
  {
    Application.Quit();
  }
}
