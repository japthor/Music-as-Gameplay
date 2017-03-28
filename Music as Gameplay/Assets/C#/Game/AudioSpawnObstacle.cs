using UnityEngine;
using System.Collections;


public class AudioSpawnObstacle : MonoBehaviour {
  public int Band;

  public GameObject Obstacle;
  public GameObject Points;
  public GameObject PowerUp;

  private enum Object
  {
    kObject_Obstacle,
    kObject_Points,
    kObject_PowerUp
  };

  private float SecondsToSpawn;
  private float Seconds;

  void Start ()
  {
    SecondsToSpawn = 0.2f;
    Seconds = SecondsToSpawn;
  }

	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      AudioManager.GetInstance.MusicLinearMapping(Band);
      Timer();
    }
  }

  void Timer()
  {
    if (SecondsToSpawn <= 0.0f)
    {
      if (AudioManager.GetInstance.GetMusicResult(Band) >= 0.8f)
      {
        Spawn();
        SecondsToSpawn = Seconds;
      }
    }
    else
      SecondsToSpawn -= Time.deltaTime;
  }

  void Spawn()
  {
    if(RandomNumber() >= 9)
    {
      if(RandomNumber() >= 7)
        InstantiateObject(Object.kObject_PowerUp);
      else
        InstantiateObject(Object.kObject_Points);
    }
    else
      InstantiateObject(Object.kObject_Obstacle);
  }

  int RandomNumber()
  {
    int value = Random.Range(0, 10);
    return value;
  }

  void InstantiateObject(Object obj)
  {
    switch (obj)
    {
      case Object.kObject_Obstacle:
        Instantiate(Obstacle, transform.position, Obstacle.transform.rotation);
        break;

      case Object.kObject_Points:
        Instantiate(Points, transform.position, Points.transform.rotation);
        break;

      case Object.kObject_PowerUp:
        Instantiate(PowerUp, transform.position, PowerUp.transform.rotation);
        break;
    }
    AudioManager.GetInstance.SetActivity(Band, 1);
  }
}
