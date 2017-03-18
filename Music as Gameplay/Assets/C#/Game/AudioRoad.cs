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

    Brightness(0.1f,0.8f,0.2f,0.8f);
    Material.SetColor("_EmissionColor", NewColor);
  }

  void Brightness(float min_frequency, float max_frequency, float min_bright, float max_bright)
  {
    if (AudioManager.GetInstance().GetResultBackGround(Band) <= min_frequency)
      NewColor = new Color((Material.color.r * min_bright) / 1, (Material.color.g * min_bright) / 1, (Material.color.b * min_bright) / 1);
    else
    {
      if (AudioManager.GetInstance().GetResultBackGround(Band) >= max_frequency)
        NewColor = new Color((Material.color.r * max_bright) / 1, (Material.color.g * max_bright) / 1, (Material.color.b * max_bright) / 1);
      else
        NewColor = new Color((Material.color.r * AudioManager.GetInstance().GetResultBackGround(Band)) / 1, (Material.color.g * AudioManager.GetInstance().GetResultBackGround(Band)) / 1, (Material.color.b * AudioManager.GetInstance().GetResultBackGround(Band)) / 1);
    }
  }
}
