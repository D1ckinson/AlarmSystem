using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    private float _minVolume = 0;
    private float _maxVolume = 100;
    private float _volumeDelta = 0.1f;

    private void Start() =>
        _audioSource.volume = 0;

    public void FadeIn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void FadeOut()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float target)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeDelta * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
