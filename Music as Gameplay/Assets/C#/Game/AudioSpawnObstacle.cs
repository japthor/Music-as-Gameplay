using UnityEngine;
using System.Collections;


public class AudioSpawnObstacle : MonoBehaviour {
  public int Band;
  public GameObject Obstacle;
  public GameObject Points;
  public Transform PositionToSpawn;
  private float SecondsToSpawn;
  private float Seconds;

  // Use this for initialization
  void Start () {
    SecondsToSpawn = 0.2f;
    Seconds = SecondsToSpawn;
  }
	
	// Update is called once per frame
	void Update () {
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
    float value = Random.Range(0.0f, 10.0f);

    if(value >= 9)
    {
      Instantiate(Points, PositionToSpawn.position, Quaternion.identity);
      AudioManager.GetInstance.SetActivity(Band, 1);
    }
    else
    {
      Instantiate(Obstacle, PositionToSpawn.position, Quaternion.identity);
      AudioManager.GetInstance.SetActivity(Band, 1);
    }
  }
}
