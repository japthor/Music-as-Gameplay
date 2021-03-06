﻿using UnityEngine;
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

  void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused)
    {
      CheckCollision();
      Shake();
    }
  }

  void CheckCollision()
  {
    if (AudioManager.GetInstance.GetHasCollideWithObstacle)
    {
      Duration = 0.5f;
      AudioManager.GetInstance.GetHasCollideWithObstacle = false;
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
