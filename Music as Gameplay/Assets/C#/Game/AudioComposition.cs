using UnityEngine;
using System.Collections;

public class AudioComposition : MonoBehaviour {

  private AudioSource AudioSource;
  private float[] Samples = new float[1024];
  private float[] VelocityFrequencyBand = new float[16];
  private float NumberOfBands;

  // Use this for initialization
  void Start ()
  {
    AudioSource = GetComponent<AudioSource>();
    NumberOfBands = 16;
  }
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused)
    {
      GetSpectrumData();
      IntegrateFrequency();
      IntegrateVelocity();
    }
  }

  void GetSpectrumData()
  {
    AudioSource.GetSpectrumData(Samples, 0, FFTWindow.BlackmanHarris);
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

      AudioManager.GetInstance.SetMusicFrequencyBand(i, (average / count) * 5);
    }

  }

  void IntegrateVelocity()
  {
    for (int i = 0; i < NumberOfBands; i++)
    {
      if (AudioManager.GetInstance.GetMusicFrequencyBand(i) > AudioManager.GetInstance.GetAlteredFrequencyBand(i))
      {
        AudioManager.GetInstance.SetAlteredFrequencyBand(i, AudioManager.GetInstance.GetMusicFrequencyBand(i));
        VelocityFrequencyBand[i] = 0.001f;
      }

      if (AudioManager.GetInstance.GetMusicFrequencyBand(i) < AudioManager.GetInstance.GetAlteredFrequencyBand(i))
      {
        float CopyFrequencyBand = AudioManager.GetInstance.GetAlteredFrequencyBand(i);
        CopyFrequencyBand -= VelocityFrequencyBand[i];
        AudioManager.GetInstance.SetAlteredFrequencyBand(i, CopyFrequencyBand);
        VelocityFrequencyBand[i] *= 1.15f;
      }
    }
  }
}
