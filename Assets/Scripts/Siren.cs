using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 100;
    private float _volumeUpStep = 0.01f;
    private bool _isPlaying;
    private WaitForSeconds _sleepTime = new(0.2f);

    private void Start() =>
        _audioSource.volume = 0;

    public void Play()
    {
        _isPlaying = true;

        StopCoroutine(StopAlarm());
        StartCoroutine(PlayAlarm());
    }

    public void Stop()
    {
        _isPlaying = false;

        StopCoroutine(PlayAlarm());
        StartCoroutine(StopAlarm());
    }

    private IEnumerator PlayAlarm()
    {
        _audioSource.Play();

        while (_isPlaying)
        {
            if (_audioSource.volume < _maxVolume)
            {
                _audioSource.volume += _volumeUpStep;
            }

            yield return _sleepTime;
        }
    }

    private IEnumerator StopAlarm()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= _volumeUpStep;

            yield return _sleepTime;
        }

        _audioSource.Stop();
    }
}
