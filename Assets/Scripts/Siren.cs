using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 100;
    private float _volumeUpStep = 0.01f;
    private float _sleepTime = 0.2f;
    private bool _isPlaying;

    private void Start()
    {
        _audioSource.volume = 0;

        StartCoroutine(Play());
    }

    public void GetAlarmStatus(bool satus) =>
        _isPlaying = satus;

    private IEnumerator Play()
    {
        WaitForSeconds wait = new(_sleepTime);

        while (true)
        {
            if (_isPlaying)
            {
                if (_audioSource.isPlaying == false)
                {
                    _audioSource.Play();
                }

                if (_audioSource.volume < _maxVolume)
                {
                    _audioSource.volume += _volumeUpStep;
                }

                yield return wait;
            }
            else if (_audioSource.volume > 0)
            {
                _audioSource.volume -= _volumeUpStep;

                yield return wait;
            }

            if (_audioSource.volume <= 0 && _audioSource.isPlaying)
            {
                _audioSource.Stop();
            }

            yield return null;
        }
    }
}
