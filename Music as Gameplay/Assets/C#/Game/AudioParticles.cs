using UnityEngine;
using System.Collections;

public class AudioParticles : MonoBehaviour {

  public int Band;
  public float VelocityToStart;
  private ParticleSystem Particles;

	// Use this for initialization
	void Start ()
  {
    Particles = GetComponent<ParticleSystem>();
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      if(Particles.tag == "Fireworks")
        ActivateFireworksParticles();
      else if(Particles.tag == "Stars")
        ActivateStarsParticles();
    }

    if (AudioManager.GetInstance.GetIsGameFinished())
      Particles.Stop();
  }

  void ActivateStarsParticles()
  {
    if (AudioManager.GetInstance.GetActivateParticles(Band))
    {
      Particles.Play();
      AudioManager.GetInstance.SetActivateParticles(Band, false);
    }
  }

  void ActivateFireworksParticles()
  {

    if (AudioManager.GetInstance.GetObjectsVelocity() >= VelocityToStart)
    {
      if (Particles.isStopped)
        Particles.Play();
    }
    else
      Particles.Stop();
  }
}
