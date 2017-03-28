using UnityEngine;
using System.Collections;

public class AudioObjectsBehaviour : MonoBehaviour {

  private Material Material;
  private bool IsMovingDown;

  public int Band;

  // Use this for initialization
  void Start ()
  {
    IsMovingDown = true;
    Material = GetComponent<MeshRenderer>().materials[0];
    Brightness(0.9f);
  }

  void Update()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      Movement();
      Scale();
    }
  }

  void Brightness(float max_bright)
  {
    Color newColor = new Color((Material.color.r * max_bright) / 1, (Material.color.g * max_bright) / 1, (Material.color.b * max_bright) / 1);
    Material.SetColor("_EmissionColor", newColor * 2.0f);
  }

  void Movement()
  {
    if (IsMovingDown)
      transform.Translate(Vector3.down * AudioManager.GetInstance.GetObjectsVelocity() * Time.deltaTime, Space.World);
    else
      transform.Translate(Vector3.back * AudioManager.GetInstance.GetObjectsVelocity() * Time.deltaTime, Space.World);
  }

  void Scale()
  {
    transform.localScale = new Vector3((AudioManager.GetInstance.GetAlteredResult(Band) * 0.4f) + 0.2f,
                                       (AudioManager.GetInstance.GetAlteredResult(Band) * 0.4f) + 0.2f,
                                       (AudioManager.GetInstance.GetAlteredResult(Band) * 0.4f) + 0.2f);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Vertical Trigger")
      IsMovingDown = true;

    else if (other.gameObject.tag == "Horizontal Trigger")
      IsMovingDown = false;

    else if (other.gameObject.tag == "Player")
    {
      if(tag == "Obstacle")
      {
        AudioManager.GetInstance.SetHasCollideWithObstacle(true);
        AudioManager.GetInstance.DecreaseObjectsVelocity(0.5f);
        AudioManager.GetInstance.SetActivity(Band, -1);
        Destroy(this.gameObject);
      }
      else if (tag == "Points")
      {
        AudioManager.GetInstance.IncreaseObjectsVelocity(0.5f);
        AudioManager.GetInstance.SetActivity(Band, -1);
        AudioManager.GetInstance.SetActivateParticles(Band, true);
        Destroy(this.gameObject);
      }
      else if (tag == "Power Up")
      {
        AudioManager.GetInstance.SetActivity(Band, -1);
        Destroy(this.gameObject);
      }
    }

    else if (other.gameObject.tag == "Destroy Trigger")
    {
      AudioManager.GetInstance.SetActivity(Band, -1);
      Destroy(this.gameObject);
    }
  }
}
