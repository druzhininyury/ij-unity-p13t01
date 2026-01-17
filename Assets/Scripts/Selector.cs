using System;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public Splittable GetSelection(Vector3 inputPosition)
    {
        Ray ray = _camera.ScreenPointToRay(inputPosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) == false
            || hitInfo.collider.TryGetComponent(out Splittable selectedSplittable) == false)
        {
            return null;
        }

        return selectedSplittable;
    }
}
