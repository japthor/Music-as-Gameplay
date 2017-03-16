using UnityEngine;
using System.Collections;

public class AudioComposition : MonoBehaviour {

  AudioSource AudioSource;
  float[] Samples = new float[1024];
  float[] VelocityFrequencyBand = new float[16];
  float NumberOfBands;

  public bool IsMuteMusic;

  // Use this for initialization
  void Start ()
  {
    AudioSource = GetComponent<AudioSource>();
    NumberOfBands = 16;
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
    int[] sampleSize = new int[16] {1, 2, 4, 6, 8, 12, 18, 26, 38, 54, 70, 88, 110, 144, 190, 253 };

    int count = 0;
    for (int i = 0; i < 16; i++)
    {
      float average = 0;
      int sample = sampleSize[i];

      int j = 0;

      for (j = 0; j < sample; j++)
      {
        average += Samples[count] * (count + 1);
        count++;
      }
     
      if (IsMuteMusic)
      {
        AudioManager.GetInstance().SetMuteFrequencyBand(i, (average / count) * 10);
      }
      else
      {
        AudioManager.GetInstance().SetNoMuteFrequencyBand(i, (average / count) * 10);
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
