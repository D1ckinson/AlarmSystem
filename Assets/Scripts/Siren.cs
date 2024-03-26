using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 100;
    private float _volumeUpStep = 0.01f;
    private float _delay = 0.2f;

    private bool _isPlaying;

    private void Start() =>
        _audioSource.volume = 0;

    public void Play()
    {
        _isPlaying = true;

        StartCoroutine(PlayAlarm());
    }

    public void Stop()
    {
        _isPlaying = false;

        StartCoroutine(StopAlarm());
    }

    private IEnumerator PlayAlarm()
    {
        WaitForSeconds wait = new(_delay);

        _audioSource.Play();

        while (_isPlaying)
        {
            if (_audioSource.volume < _maxVolume)
            {
                _audioSource.volume += _volumeUpStep;
            }

            yield return wait;
        }
    }

    private IEnumerator StopAlarm()
    {
        WaitForSeconds wait = new(_delay);

        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= _volumeUpStep;

            yield return wait;
        }

        _audioSource.Stop();
    }
}
