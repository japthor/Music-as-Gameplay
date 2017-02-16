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

    if (Band < 0 || Band > 7)
    {
      Band = 0;
    }

    InitialScale = 1f;
    AudioManager.GetInstance().SetMaximumValueBackGround(Band, 1);
    Material = GetComponent<MeshRenderer>().materials[0];
  }
	
	// Update is called once per frame
	void Update ()
  {
    if( a== 0)
    {
      AudioManager.GetInstance().LinearMappingBackGround(Band);
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
