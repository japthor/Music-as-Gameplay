using UnityEngine;
using System.Collections;

public class AudioComposition : MonoBehaviour {

  AudioSource AudioSource;
  float[] Samples = new float[512];
  float[] VelocityFrequencyBand = new float[8];
  float NumberOfBands;

  public bool IsMuteMusic;

  // Use this for initialization
  void Start ()
  {
    AudioSource = GetComponent<AudioSource>();
    NumberOfBands = 8;
  }
	
	// Update is called once per frame
	void Update ()
  {
    GetSpectrumData();
    IntegrateFrequency();

    if (!IsMuteMusic)
    {
      IntegrateVelocity();
    }
  }

  void GetSpectrumData()
  {
    AudioSource.GetSpectrumData(Samples, 0, FFTWindow.Blackman);
  }

  void IntegrateFrequency()
  {
    int count = 0;

    for (int i = 0; i < NumberOfBands; i++)
    {
      float amplitude = 0;
      int sample = 0;
    
      sample = (i * 2) + 2;

      if(sample == 7)
      {
        sample += 2;
      }


      for(int j = 0; j < sample; j++)
      {
        amplitude += Samples[count] * (count + 1);
        count++;
      }

      if (IsMuteMusic)
      {
        AudioManager.GetInstance().SetMuteFrequencyBand(i, (amplitude / count) * 10);
      }
      else
      {
        AudioManager.GetInstance().SetNoMuteFrequencyBand(i, (amplitude / count) * 10);
      }
    }
  }

  void IntegrateVelocity()
  {
    for (int i = 0; i < NumberOfBands; i++)
    {
      if (AudioManager.GetInstance().GetNoMuteFrequencyBand(i) > AudioManager.GetInstance().GetFrequencyBandBackGround(i))
      {
        AudioManager.GetInstance().SetFrequencyBandBackGround(i, AudioManager.GetInstance().GetNoMuteFrequencyBand(i));
        VelocityFrequencyBand[i] = 0.001f;
      }

      if (AudioManager.GetInstance().GetNoMuteFrequencyBand(i) < AudioManager.GetInstance().GetFrequencyBandBackGround(i))
      {
        float CopyFrequencyBand = AudioManager.GetInstance().GetFrequencyBandBackGround(i);
        CopyFrequencyBand -= VelocityFrequencyBand[i];
        AudioManager.GetInstance().SetFrequencyBandBackGround(i, CopyFrequencyBand);
        VelocityFrequencyBand[i] *= 1.2f;
      }
    }
  }
}
