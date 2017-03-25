using UnityEngine;
using System.Collections;

public class AudioParticles : MonoBehaviour {

  public int Band;
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
      ActivateParticle();
  }

  void ActivateParticle()
  {
    if (AudioManager.GetInstance.GetActivateParticles(Band))
    {
      Particles.Play();
      AudioManager.GetInstance.SetActivateParticles(Band, false);
    }
  }
}
