using UnityEngine;
using System.Collections;

public class AudioObstacle : MonoBehaviour {

  public int band;
  bool MoveLeft;
  bool MoveRight;
  float MaxVelocity;
  float Velocity;
  Vector3 InitialPosition;
  // Use this for initialization
  void Start () {
    MoveLeft = true;
    MoveRight = false;
    MaxVelocity = 0.06f;
    Velocity = 0.0f;
    AudioManager.GetInstance().SetMaximumValue(band, 1);
    InitialPosition = transform.localPosition;
  }
	
	// Update is called once per frame
	void Update () {
    AudioManager.GetInstance().LinearMapping(band);
    //transform.position += Vector3.back * Time.deltaTime;
    CheckFrequency();

    if (!CheckOffset())
    {
      Movement();
    }
  }

  void CheckFrequency()
  {
    Vector3 pos = transform.localPosition;
    float actualValue = AudioManager.GetInstance().GetResult(band);

    if (actualValue < 0)
    {
      actualValue = 0;
    }

    if (actualValue >= 0.7f && actualValue <= 1.0f)
    {
      Velocity = MaxVelocity;
    }

  }

  void Movement()
  {
    Vector3 pos = transform.localPosition;

    if (MoveLeft)
    {
      if(Velocity <= 0)
      {
        Velocity = 0;
      }
      else
      {
        Velocity += -(0.001f);
        pos[0] += -(Velocity);
        transform.localPosition = pos;
      }
     
    }

    if (MoveRight)
    {
      if (Velocity <= 0)
      {
        Velocity = 0;
      }
      else
      {
        Velocity += -(0.001f);
        pos[0] += (Velocity);
        transform.localPosition = pos;
      }
    }

  }

  bool CheckOffset()
  {
    Vector3 pos = transform.localPosition;

    if (MoveLeft)
    {
      if (pos[0] <= InitialPosition.x - 2.0f)
      {
        pos[0] = InitialPosition.x - 2.0f;
        transform.localPosition = pos;
        MoveLeft = false;
        MoveRight = true;
        return true;
      }
    }

    if (MoveRight)
    {
      if (pos[0] >= InitialPosition.x + 2.0f)
      {
        pos[0] = InitialPosition.x + 2.0f;
        transform.localPosition = pos;
        MoveRight = false;
        MoveLeft = true;
        return true;
      }
    }
    return false;
  }
}
