using UnityEngine;
using System.Collections;

public class AudioBackGroundMovement : MonoBehaviour {

  public int Band;
  public float MultiplyScale;
  float InitialScale;
  Material Material;
  public int a;

  // Use this for initialization
  void Start ()
  {
    InitialScale = 1.0f;
    Material = GetComponent<MeshRenderer>().materials[0];
  }
	
	// Update is called once per frame
	void Update ()
  {
    AudioManager.GetInstance().LinearMappingBackGround(Band);
    if ( a== 0)
    {
      transform.localScale = new Vector3(transform.localScale.x, (AudioManager.GetInstance().GetResultBackGround(Band) * MultiplyScale) + InitialScale, transform.localScale.z);
      Color color = new Color(AudioManager.GetInstance().GetResultBackGround(Band), AudioManager.GetInstance().GetResultBackGround(Band), AudioManager.GetInstance().GetResultBackGround(Band));
      Material.SetColor("_EmissionColor", color);
    }
    

    if (a == 1)
    {
      transform.localScale = new Vector3((AudioManager.GetInstance().GetResultBackGround(Band) * MultiplyScale) + InitialScale, 1, (AudioManager.GetInstance().GetResultBackGround(Band) * MultiplyScale) + InitialScale);
    }
    
  }
}
