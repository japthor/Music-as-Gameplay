using UnityEngine;
using System.Collections;

public class AudioObstacle : MonoBehaviour {

  void Start ()
  {
    
  }
	
	
	void Update ()
  {
    Move();
    Delete();
  }

  void Move()
  {
    transform.position += Vector3.back * Time.deltaTime * 3;
  }

  void Delete()
  {
    if (transform.localPosition.z <= -20.0f)
    {
      Destroy(this.gameObject);
    }
  }

}
