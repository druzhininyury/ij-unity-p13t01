using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _pointUserAction = 0;

    public event Action<Vector3> UserPointAction;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(_pointUserAction))
        {
            UserPointAction?.Invoke(Input.mousePosition);
        }
    }
}
