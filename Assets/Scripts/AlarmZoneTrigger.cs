using System.Collections;
using UnityEngine;

public class AlarmZoneTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _maxVolume = 100;
    private float _volumeUpStep = 0.01f;
    private float _delay = 0.2f;
    private bool _hasThief;

    private void Start()
    {
        _audioSource.volume = 0;
        StartCoroutine(PlayAlarm());
    }

    private void Update()
    {
        if (_hasThief && _audioSource.isPlaying == false)
            _audioSource.Play();
        else if (_audioSource.volume <= 0 && _audioSource.isPlaying)
            _audioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
            _hasThief = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
            _hasThief = false;
    }

    private IEnumerator PlayAlarm()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            while (_hasThief)
            {
                if (_audioSource.volume < _maxVolume)
                {
                    _audioSource.volume += _volumeUpStep;
                }

                yield return wait;
            }

            while (_audioSource.volume > 0)
            {
                _audioSource.volume -= _volumeUpStep;
                yield return wait;
            }

            yield return null;
        }
    }
}
