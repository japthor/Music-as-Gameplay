using UnityEngine;
using System.Collections;

public class AudioRoad : MonoBehaviour {

  public int Band;
  private Material Material;
  private Color NewColor;

  // Use this for initialization
  void Start () {
    Material = GetComponent<MeshRenderer>().materials[0];
  }
	
	// Update is called once per frame
	void Update ()
  {
    AudioManager.GetInstance().LinearMappingBackGround(Band);
    Brightness();
    Material.SetColor("_EmissionColor", NewColor);
  }

  void Brightness()
  {
    switch (Band)
    {
      case 0:
        if (AudioManager.GetInstance().GetResultBackGround(Band) <= 0.1f)
        {
          NewColor = new Color(0.2f, 0.0f, 0.0f);
        }
        else
        {
          if (AudioManager.GetInstance().GetResultBackGround(Band) >= 0.8f)
            NewColor = new Color(0.8f, 0.0f, 0.0f);
          else
          {
            NewColor = new Color(AudioManager.GetInstance().GetResultBackGround(Band), 0.0f, 0.0f);
          }
            
        }
        break;

      case 1:
        if (AudioManager.GetInstance().GetResultBackGround(Band) <= 0.1f)
          NewColor = new Color(0.2f, 0.1f, 0.0f);
        else
        {
          if (AudioManager.GetInstance().GetResultBackGround(Band) >= 0.8f)
            NewColor = new Color(0.8f, 0.4f, 0.0f);
          else
            NewColor = new Color(AudioManager.GetInstance().GetResultBackGround(Band), AudioManager.GetInstance().GetResultBackGround(Band) / 2, 0.0f);
        }
        break;
    }
  }
}
