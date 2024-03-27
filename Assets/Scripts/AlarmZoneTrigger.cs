using UnityEngine;

public class AlarmZoneTrigger : MonoBehaviour
{
    [SerializeField] private Siren _siren;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
            _siren.FadeIn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
            _siren.FadeOut();
    }
}
