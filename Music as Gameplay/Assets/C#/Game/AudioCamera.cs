using UnityEngine;
using System.Collections;

public class AudioCamera : MonoBehaviour {

  private float Duration;
  private float Amount;
  private float Decrease;
  private Vector3 Position;
 
	// Use this for initialization
	void Start ()
  {
    Duration = 0.0f;
    Amount = 0.5f;
    Decrease = 1.0f;
    Position = transform.localPosition;
  }

  // Update is called once per frame
  void Update ()
  {
    CheckCollision();
    Shake();
  }

  void CheckCollision()
  {
    if (AudioManager.GetInstance().GetHasCollideWithObstacle())
    {
      Duration = 0.5f;
      AudioManager.GetInstance().SetHasCollideWithObstacle(false);
    }
  }

  void Shake()
  {
    if (Duration > 0)
    {
      transform.localPosition = Position + Random.insideUnitSphere * Amount;
      Duration -= Time.deltaTime * Decrease;
    }
    else
    {
      transform.localPosition = Position;
      Duration = 0.0f;
    }
  }
}
