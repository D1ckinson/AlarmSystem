using UnityEngine;

public class AlarmZoneTrigger : MonoBehaviour
{
    [SerializeField] private Siren _siren;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
            _siren.GetAlarmStatus(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
            _siren.GetAlarmStatus(false);
    }
}
