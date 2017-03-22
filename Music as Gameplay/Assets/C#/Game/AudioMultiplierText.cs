using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioMultiplierText : MonoBehaviour {

  public int Band;

	// Use this for initialization
	void Start ()
  {
	
	}
	
	// Update is called once per frame
	void Update ()
  {
    MultiplierText();
    SetMultiplierText();
  }

  void MultiplierText()
  {
    if (AudioManager.GetInstance().GetActivity(Band) == 0)
      AudioManager.GetInstance().SetMultiplier(Band, 0);

    else if (AudioManager.GetInstance().GetActivity(Band) >= 1 && AudioManager.GetInstance().GetActivity(Band) < 5)
      AudioManager.GetInstance().SetMultiplier(Band, 1);

    else if (AudioManager.GetInstance().GetActivity(Band) >= 5 && AudioManager.GetInstance().GetActivity(Band) < 10)
      AudioManager.GetInstance().SetMultiplier(Band, 2);

    else if (AudioManager.GetInstance().GetActivity(Band) >= 10 && AudioManager.GetInstance().GetActivity(Band) < 15)
      AudioManager.GetInstance().SetMultiplier(Band, 3);

    else if (AudioManager.GetInstance().GetActivity(Band) >= 15 && AudioManager.GetInstance().GetActivity(Band) < 20)
      AudioManager.GetInstance().SetMultiplier(Band, 4);

    else if (AudioManager.GetInstance().GetActivity(Band) >= 20 && AudioManager.GetInstance().GetActivity(Band) < 25)
      AudioManager.GetInstance().SetMultiplier(Band, 5);
  }

  void SetMultiplierText()
  {
    GetComponent<TextMesh>().text = AudioManager.GetInstance().GetMultiplier(Band).ToString();

  }
}
