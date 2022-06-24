using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMarker
{
    void ChangeColor(Color color);
    void SetTarget();
    void RemoveTarget();
}

