﻿using UnityEngine;
using System.Collections;


public class AudioSpawnObject : MonoBehaviour {
  public int Band;
  public GameObject ObjectToSpawn;
  public Transform PositionToSpawn;
  float SecondsToSpawn;
  float MultiplyScale;
  float Seconds;
  float MaxFrequency;


  // Use this for initialization
  void Start () {
    SecondsToSpawn = 0.2f;
    Seconds = SecondsToSpawn;
    MultiplyScale = 5.0f;
    MaxFrequency = 0.0f;
  }
	
	// Update is called once per frame
	void Update () {
    AudioManager.GetInstance().NoMuteLinearMapping(Band);
    Timer();
  }

  void Timer()
  {
    if(Seconds <= 0.0f)
    {
      Spawn();
      Seconds = SecondsToSpawn;
    }
    else
    {
      float frequency = AudioManager.GetInstance().GetNoMuteResult(Band);
      Mathf.Round(frequency);

      if (frequency <= 0.0f)
      {
        frequency = 0.0f;
      }
     
      if (frequency > MaxFrequency)
      {
        MaxFrequency = frequency;
      }
 
      Seconds -= Time.deltaTime;
    }
  }

  void Spawn()
  {
    GameObject instantiate = Instantiate(ObjectToSpawn, PositionToSpawn.position, Quaternion.identity) as GameObject;
    instantiate.transform.localScale = new Vector3(instantiate.transform.localScale.x, MaxFrequency * MultiplyScale, instantiate.transform.localScale.z);
    MaxFrequency = 0.0f;
  }
}
