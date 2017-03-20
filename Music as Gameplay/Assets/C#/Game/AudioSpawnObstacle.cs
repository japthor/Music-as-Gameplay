using UnityEngine;
using System.Collections;


public class AudioSpawnObstacle : MonoBehaviour {
  public int Band;
  public GameObject ObjectToSpawn;
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
    AudioManager.GetInstance().NoMuteLinearMapping(Band);
    Timer();
  }

  void Timer()
  {
    if (SecondsToSpawn <= 0.0f)
    {
      if (AudioManager.GetInstance().GetNoMuteResult(Band) >= 0.8f)
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
    Instantiate(ObjectToSpawn, PositionToSpawn.position, Quaternion.identity);
  }
}
