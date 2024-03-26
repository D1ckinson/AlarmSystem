using UnityEngine;

public class AlarmZoneTrigger : MonoBehaviour
{
    [SerializeField] private Siren _siren;

    private bool _isSyrenPlay;

    private void Update()
    {
        //if (_isSyrenPlay && _siren.isPlaying == false)
        //    _siren.Play();
        //else if (_siren.volume <= 0 && _siren.isPlaying)
        //    _siren.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
            _siren.Play();
        //_isSyrenPlay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
            _siren.Stop();
        //_isSyrenPlay = false;
    }
}
