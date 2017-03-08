using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  Rigidbody RB;
  float Speed;
	
	void Start ()
  {
    RB = GetComponent<Rigidbody>();
    Speed = 3.0f;
  }

	void Update ()
  {
    Movement();
    Jump();
  }

  void Jump()
  {
    if (Input.GetKeyDown("space"))
    {
      RB.velocity = new Vector3(0.0f, 6.0f, 0.0f);
    }
  }

  void Movement()
  {
    if (Input.GetKey(KeyCode.A))
    {
      transform.position -= new Vector3(Speed * Time.deltaTime, 0.0f, 0.0f);
    }

    if (Input.GetKey(KeyCode.D))
    {
      transform.position += new Vector3(Speed * Time.deltaTime, 0.0f, 0.0f);
    }
  }
}
