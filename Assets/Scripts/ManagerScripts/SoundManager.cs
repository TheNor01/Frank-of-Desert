using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource musicSource, enemySource, playerSource;
    [SerializeField] AudioClip soundTrack, fireAttack, lost;
    [SerializeField] AudioClip enemyDeath;

    public AudioMixer audioMixer;
    float value;
    private void Awake()
    {
        instance = this;
        bool result = audioMixer.GetFloat("volume", out value);
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        musicSource.volume = 1f * value;
        Debug.Log("Vol :  "+musicSource.volume+" value : "+value);
        int qualityLevel = QualitySettings.GetQualityLevel();
        Debug.Log("Quality"+qualityLevel);

        musicSource.clip = soundTrack;
        musicSource.Play();

        enemySource = gameObject.AddComponent<AudioSource>();
        enemySource.volume = 0.5f * value;

        playerSource = gameObject.AddComponent<AudioSource>();
        playerSource.volume = 0.5f * value;
    }
    


    public void PlayPlayerAttack()
    {
        playerSource.clip = fireAttack;
        playerSource.Play();
    }

    public void stopMain()
    {
        musicSource.Stop();
    }

    public void PlayDefeat()
    {
        playerSource.clip = lost;
        playerSource.Play();
    }

    public void PlayEnemyDestroy()
    {
        enemySource.clip = enemyDeath;
        enemySource.Play();
    }

    public void volueMainDown()
    {
        musicSource.volume = 0.4f * value;
    }

/*
    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 5.0f);

        return linear;
    }
  */
}
