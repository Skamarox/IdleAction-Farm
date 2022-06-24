using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    private List<IMarker> _Marker = new List<IMarker>();
    [SerializeField] private List<Transform> MarkerTransform = new List<Transform>();
    private float RangeForMarker = 1.65f;

    public void Add(IMarker marker, Transform transform)
    {
        _Marker.Add(marker);
        MarkerTransform.Add(transform);
    }

    public void RemoveFromMarker(IMarker marker, Transform transform)
    {
        _Marker.Remove(marker);
        MarkerTransform.Remove(transform);
        marker.ChangeColor(Color.white);
        marker.RemoveTarget();
    }

    private void Update()
    {
        if(_Marker.Count > 0)
        {
            for(int i = 0; i < _Marker.Count; i++)
            {
                Vector3 distance = MarkerTransform[i].position - transform.position;
                float dist = distance.magnitude;
                if (dist < RangeForMarker)
                {
                    _Marker[i].ChangeColor(Color.red);
                    _Marker[i].SetTarget();
                }
                else
                {
                    _Marker[i].ChangeColor(Color.white);
                    _Marker[i].RemoveTarget();
                }
            }
        }
    }
}
