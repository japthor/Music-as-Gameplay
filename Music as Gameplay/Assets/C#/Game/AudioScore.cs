using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioScore : MonoBehaviour {

  public Text ScoreText;

  // Use this for initialization
  void Start ()
  {
    
  }
	
	// Update is called once per frame
	void Update ()
  {
    ScoreText.text = AudioManager.GetInstance.GetScore().ToString();
	}
}
