using UnityEngine;
using System.Collections;

public class AudioSpawnObject : MonoBehaviour {
  static int hola;
  public int Band;
  public GameObject ObjectToSpawn;
  public Transform SpawnPoint;
  float timeLeft;
  bool asco;


  // Use this for initialization
  void Start () {
    AudioManager.GetInstance().SetMaximumValue(Band, 1);
    timeLeft = 1.0f;
    hola = 0;
    asco = false;
  }
	
	// Update is called once per frame
	void Update () {
   

    /*if (AudioManager.GetInstance().GetResult(Band) > 0.80f && !asco)
    {
      Debug.Log(hola);
      hola++;
      asco = true;
      Spawn();
    }

    if (asco)
    {
      if(timeLeft >= 0.3f)
      {
        asco = false;
        timeLeft = 0;
      }else
      {
        timeLeft += Time.deltaTime;
      }
    }*/
  }

  void Spawn()
  {
    int random = (int)Random.Range(0.0f, 16.0f);

    if (random % 2 != 0)
    {
      random -= 1;
    }
    Vector3 position = SpawnPoint.position;
    position[0] += random;

    Instantiate(ObjectToSpawn, position, Quaternion.identity);
  }
}
