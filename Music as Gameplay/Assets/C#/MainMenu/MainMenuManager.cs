using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

  public Transform[] Menus = new Transform[5];
  public Toggle[] Toggles = new Toggle[3];
  public AudioSource[] Music = new AudioSource[3];
  public Slider VolumeSlider;

  void Start ()
  {
    GameObject Manager = GameObject.Find("AudioManager");

    if (Manager == null)
      VolumeSlider.value = 1.0f;
    else
      VolumeSlider.value = AudioManager.GetInstance.GetVolume;

  }

  public void Play(int scene)
  {
    if (Toggles[0].isOn || Toggles[1].isOn | Toggles[2].isOn)
      SceneManager.LoadScene(scene);
  }
  
  public void Exit()
  {
    Application.Quit();
  }

  public void Volume()
  {
    AudioManager.GetInstance.GetVolume = VolumeSlider.value;

    for(int i = 0; i < Music.Length; i++)
      Music[i].volume = VolumeSlider.value;
  }

  public void BackFromOptionsMenu()
  {
    MoveMenu(Menus[3], Menus[0]);
  }

  public void ActivateOptionsMenu()
  {
    MoveMenu(Menus[0], Menus[3]);
  }

  public void AviteCreditsMenu()
  {
    MoveMenu(Menus[0], Menus[2]);
  }

  public void BackFromCreditsMenu()
  {
    MoveMenu(Menus[2], Menus[0]);
  }

  public void ActivatePlayMenu()
  {
    MoveMenu(Menus[0], Menus[1]);
    AudioManager.GetInstance.ResetVariables();
  }

  public void BackFromPlayMenu()
  {
    MoveMenu(Menus[1], Menus[0]);
  }

  public void ActivateInstructionsMenu()
  {
    MoveMenu(Menus[0], Menus[4]);
  }

  public void BackFromInstructionMenu()
  {
    MoveMenu(Menus[4], Menus[0]);
  }

  void MoveMenu(Transform from, Transform to)
  {
    if (from.gameObject.activeInHierarchy)
    {
      to.gameObject.SetActive(true);
      from.gameObject.SetActive(false);
    }
  }


  public void Toggle(int music)
  {
    switch (music)
    {
      case 1:
        if (Toggles[0].isOn)
        {
          AudioManager.GetInstance.GetSongs = 1;
          PlayMusic(new int[] {0, 1, 2}, new int[] {1, 2});
        }
        else
          Music[0].Stop();
        break;

      case 2:
        if (Toggles[1].isOn)
        {
          AudioManager.GetInstance.GetSongs = 2;
          PlayMusic(new int[] { 1, 0, 2 }, new int[] {0, 2});
        }
        else
          Music[1].Stop();
        break;

      case 3:
        if (Toggles[2].isOn)
        {
          AudioManager.GetInstance.GetSongs = 3;
          PlayMusic(new int[] {2, 0, 1}, new int[] {0, 1});
        }
        else
          Music[2].Stop();
        break;

      default:
        break;       
    }
  }

  void PlayMusic(int[] music, int[] toggle)
  {
    Toggles[toggle[0]].isOn = false;
    Toggles[toggle[1]].isOn = false;

    Music[music[0]].Play();
    Music[music[1]].Stop();
    Music[music[2]].Stop();
  }
}
