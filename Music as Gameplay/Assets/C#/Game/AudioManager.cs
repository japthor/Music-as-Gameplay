using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour{

  private static AudioManager Instance;

  private float[] MusicFrequencyBand = new float[16];
  private float[] MusicMaximumValue = new float[16];
  private float[] MusicResult = new float[16];

  private float[] AlteredFrequencyBand = new float[16];
  private float[] AlteredMaximumValue = new float[16];
  private float[] AlteredResult = new float[16];

  private bool HasCollideWithObstacle;
  private int PlayerPosition;

  private float ObjectsVelocity;
  private float MinObjectsVelocity;
  private float MaxObjectsVelocity;

  private int Score;
  private int[] Activity = new int[16];
  private int[] Multiplier = new int[16];
  private bool[] ActivateParticles = new bool[16];

  private bool IsPaused;
  private float Volume;

  private int Songs;

  private bool IsGameFinished;

  private bool GotPowerUp;
  private bool IsActivePowerUp;
  private float PowerUpTime;

  public static AudioManager GetInstance
  {
    get
    {
      if (Instance == null)
        Instance = new GameObject("AudioManager").AddComponent<AudioManager>();
      return Instance;

    }
  }

  void Awake()
  {
    if (Instance)
    {
      DestroyImmediate(gameObject);
    }else
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }

  }

  void Start()
  {
    for(int i = 0; i < 16; i++)
    {
      MusicFrequencyBand[i] = 0.0f;
      MusicMaximumValue[i] = 1.0f;
      MusicResult[i] = 0.0f;

      AlteredFrequencyBand[i] = 0.0f;
      AlteredMaximumValue[i] = 1.0f;
      AlteredResult[i] = 0.0f;

      Activity[i] = 0;
      Multiplier[i] = 0;

      ActivateParticles[i] = false;
    }

    HasCollideWithObstacle = false;
    PlayerPosition = 7;

    ObjectsVelocity = 6.0f;
    MinObjectsVelocity = ObjectsVelocity;
    MaxObjectsVelocity = 10.0f;

    Score = 0;

    IsPaused = false;
    Volume = 1.0f;
    Songs =  1;

    IsGameFinished = false;
    GotPowerUp = false;
    IsActivePowerUp = false;
    PowerUpTime = 4.0f;
  }

  void Update()
  {

  }

  public void SetMusicFrequencyBand(int band, float frequency)
  {
    MusicFrequencyBand[band] = frequency;
  }

  public float GetMusicFrequencyBand(int band)
  {
    return MusicFrequencyBand[band];
  }

  public void SetMusicMaximumValue(int band, float value)
  {
    MusicMaximumValue[band] = value;
  }

  public float GetMusicMaximumValue(int band)
  {
    return MusicMaximumValue[band];
  }

  public void SetMusicResult(int band, float result)
  {
    MusicResult[band] = result;
  }

  public float GetMusicResult(int band)
  {
    return MusicResult[band];
  }

  public void MusicLinearMapping(int band)
  {
    float value = MusicFrequencyBand[band];

    if (value < 0)
    {
      value = 0;
    }

    if (value > MusicMaximumValue[band])
    {
      MusicMaximumValue[band] = MusicFrequencyBand[band];
    }

    MusicResult[band] = (value - 0) / (MusicMaximumValue[band] - 0);

    if (float.IsNaN(MusicResult[band]))
    {
      MusicResult[band] = 0;
    }
  }

  public void SetAlteredFrequencyBand(int band, float frequency)
  {
    AlteredFrequencyBand[band] = frequency;
  }

  public float GetAlteredFrequencyBand(int band)
  {
    return AlteredFrequencyBand[band];
  }

  public void SetAlteredMaximumValue(int band, float value)
  {
    AlteredMaximumValue[band] = value;
  }

  public float GetAlteredMaximumValue(int band)
  {
    return AlteredMaximumValue[band];
  }

  public void SetAlteredResult(int band, float result)
  {
    AlteredResult[band] = result;
  }

  public float GetAlteredResult(int band)
  {
    return AlteredResult[band];
  }

  public void AlteredLinearMapping(int band)
  {
    float value = AlteredFrequencyBand[band];

    if (value < 0)
    {
      value = 0;
    }

    if (value > AlteredMaximumValue[band])
    {
      AlteredMaximumValue[band] = AlteredFrequencyBand[band];
    }

    AlteredResult[band] = (value - 0) / (AlteredMaximumValue[band] - 0);

    if (float.IsNaN(AlteredResult[band]))
    {
      AlteredResult[band] = 0;
    }
  }

  public void SetHasCollideWithObstacle(bool result)
  {
    HasCollideWithObstacle = result;
  }

  public bool GetHasCollideWithObstacle()
  {
    return HasCollideWithObstacle;
  }

  public void SetPlayerPosition(int result)
  {
    PlayerPosition = result;
  }

  public int GetPlayerPosition()
  {
    return PlayerPosition;
  }

  public void DecreaseObjectsVelocity(float result)
  {
    if (ObjectsVelocity <= MinObjectsVelocity)
      ObjectsVelocity = MinObjectsVelocity;
    else
      ObjectsVelocity -= result;
  }

  public void IncreaseObjectsVelocity(float result)
  {
    if (ObjectsVelocity >= MaxObjectsVelocity)
      ObjectsVelocity = MaxObjectsVelocity;
    else
      ObjectsVelocity += result;
  }

  public float GetObjectsVelocity()
  {
    return ObjectsVelocity;
  }

  public void SetMinObjectsVelocity(float result)
  {
    MinObjectsVelocity = result;
  }

  public float GetMinObjectsVelocity()
  {
    return MinObjectsVelocity;
  }

  public void SetMaxObjectsVelocity(float result)
  {
    MaxObjectsVelocity = result;
  }

  public float GetMaxObjectsVelocity()
  {
    return MaxObjectsVelocity;
  }

  public void AddScore(int result)
  {
      Score += result;
  }

  public void SubstractScore(int result)
  {
    if (Score - result <= 0)
      Score = 0;
    else
      Score -= result;
  }

  public int GetScore()
  {
    return Score;
  }

  public void SetActivity(int band, int result)
  {
    Activity[band] += result;
  }

  public int GetActivity(int band)
  {
    return Activity[band];
  }

  public void SetMultiplier(int band, int result)
  {
    Multiplier[band] = result;
  }

  public int GetMultiplier(int band)
  {
    return Multiplier[band];
  }

  public void SetActivateParticles(int band, bool result)
  {
    ActivateParticles[band] = result;
  }

  public bool GetActivateParticles(int band)
  {
    return ActivateParticles[band];
  }

  public void SetIsPaused(bool result)
  {
    IsPaused = result;
  }

  public bool GetIsPaused()
  {
    return IsPaused;
  }

  public void SetVolume(float result)
  {
    Volume = result;
  }

  public float GetVolume()
  {
    return Volume;
  }

  public void SetSongs(int result)
  {
    Songs = result;
  }

  public int GetSongs()
  {
    return Songs;
  }

  public void SetIsGameFinished(bool result)
  {
    IsGameFinished = result;
  }

  public bool GetIsGameFinished()
  {
    return IsGameFinished;
  }

  public void SetIsActivePowerUp(bool result)
  {
    IsActivePowerUp = result;
  }

  public bool GetIsActivePowerUp()
  {
    return IsActivePowerUp;
  }

  public void SetGotPowerUp(bool result)
  {
    GotPowerUp = result;
  }

  public bool GetGotPowerUp()
  {
    return GotPowerUp;
  }

  public void SetPowerUpTime(float result)
  {
    PowerUpTime = result;
  }

  public float GetPowerUpTime()
  {
    return PowerUpTime;
  }

  public void ResetVariables()
  {
    for (int i = 0; i < 16; i++)
    {
      MusicFrequencyBand[i] = 0.0f;
      MusicMaximumValue[i] = 1.0f;
      MusicResult[i] = 0.0f;

      AlteredFrequencyBand[i] = 0.0f;
      AlteredMaximumValue[i] = 1.0f;
      AlteredResult[i] = 0.0f;

      Activity[i] = 0;
      Multiplier[i] = 0;

      ActivateParticles[i] = false;
    }

    HasCollideWithObstacle = false;
    PlayerPosition = 7;

    ObjectsVelocity = 6.0f;

    Score = 0;

    IsPaused = false;
    IsGameFinished = false;
    GotPowerUp = false;
    IsActivePowerUp = false;
    PowerUpTime = 4.0f;

    //Volume = 1.0f;
  }
}
