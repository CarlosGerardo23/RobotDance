using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
  [SerializeField] private AudioClip _audienceHappy;
  [SerializeField] private AudioClip _audienceAngry;
  [SerializeField] private AudioSource _audienceAudioSource;
  [SerializeField] private AudioSource _globalMusicAudioSource;
  [SerializeField] private AudioClip _track1;
  [SerializeField] private AudioClip _track2;
  [SerializeField] private float _timeUntilTrackSound;
  private void Awake()
  {

    _audienceAudioSource.playOnAwake = false;
    _audienceAudioSource.loop = false;
  }

  private IEnumerator Start()
  {
    yield return new WaitForSeconds(_timeUntilTrackSound);
    PlayGlobalTrack1();
  }
  private void OnEnable()
  {
    ScoreManager.happyAudience += PlayHappyClip;
    ScoreManager.angryAudience += PlayAngryClip;
  }

  private void PlayAngryClip()
  {
    if (_audienceAudioSource.isPlaying) return;
    _audienceAudioSource.clip = _audienceHappy;
    _audienceAudioSource.Play();
  }

  private void PlayHappyClip()
  {
    if (_audienceAudioSource.isPlaying) return;
    _audienceAudioSource.clip = _audienceAngry;
    _audienceAudioSource.Play();
  }

  public void PlayGlobalTrack1()
  {
    _globalMusicAudioSource.Stop();
    _globalMusicAudioSource.clip = _track1;
    _globalMusicAudioSource.Play();
  }
  public void PlayGlobalTrack2()
  {
    _globalMusicAudioSource.Stop();
    _globalMusicAudioSource.clip = _track2;
    _globalMusicAudioSource.Play();
  }
}
