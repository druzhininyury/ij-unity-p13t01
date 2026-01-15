using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public GameObject GetSelection()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) == false)
        {
            return null;
        }

        return hitInfo.collider.gameObject;
    }
}
