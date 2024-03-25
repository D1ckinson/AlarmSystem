using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;
    [SerializeField] private float _speed;

    private Transform[] _waypoints;
    private int _index;

    private void Start()
    {
        _waypoints = new Transform[_waypointsParent.childCount];

        for (int i = 0; i < _waypointsParent.childCount; i++)
            _waypoints[i] = _waypointsParent.GetChild(i);

        StartCoroutine(FollowRoute());
    }

    private IEnumerator FollowRoute()
    {
        Transform waypoint;

        while (_index <= _waypoints.Length - 1)
        {
            waypoint = _waypoints[_index];

            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);
            transform.LookAt(waypoint);

            if (transform.position == waypoint.position)
                _index++;

            yield return null;
        }
    }
}
