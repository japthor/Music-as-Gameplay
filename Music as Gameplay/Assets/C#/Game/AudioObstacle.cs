using UnityEngine;
using System.Collections;

public class AudioObstacle : MonoBehaviour {

  private Material Material;
  private float Velocity;
  private Vector3 LastPosition;
  private bool IsMovingDown;

  void Start ()
  {
    Material = GetComponent<MeshRenderer>().materials[0];
    Velocity = 6.5f;
    Brightness(0.9f);
  }
	
	
	void Update ()
  {
    Movement();
  }

  void Brightness(float max_bright)
  {
    Color newColor = new Color((Material.color.r * max_bright) / 1, (Material.color.g * max_bright) / 1, (Material.color.b * max_bright) / 1);
    Material.SetColor("_EmissionColor", newColor * 2.0f);
  }

  void Movement()
  {
    if (IsMovingDown)
      transform.Translate(Vector3.down * Velocity * Time.deltaTime);
    else
      transform.Translate(Vector3.back * Velocity * Time.deltaTime);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Vertical Trigger")
      IsMovingDown = true;

    if (other.gameObject.tag == "Horizontal Trigger")
      IsMovingDown = false;

    if (other.gameObject.tag == "Destroy Trigger")
      Destroy(this.gameObject);
  }
}
