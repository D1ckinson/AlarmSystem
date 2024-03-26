using UnityEngine;

public class AlarmZoneTrigger : MonoBehaviour
{
    [SerializeField] private Siren _siren;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
            _siren.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
            _siren.Stop();
    }
}
