using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private CubeInitializer _cubePrefab;

    private readonly int _minSplitParts = 2;
    private readonly int _maxSplitParts = 6;

    private readonly float _splitScaleMultiplier = 0.5f;
    private readonly float _splitChanceMultiplier = 0.5f;

    private readonly float _explosionForce = 8f;
    private readonly float _explosionRadius = 1f;
    
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit))
            {
                return;
            }

            CubeInitializer selectedCube = hit.collider.GetComponentInParent<CubeInitializer>();

            if (selectedCube == null)
            {
                return;
            }

            SplitCube(selectedCube);
        }
    }

    private void SplitCube(CubeInitializer cube)
    {
        bool isSplitRollSuccess = Random.value < cube.SplitChance;

        if (isSplitRollSuccess == false)
        {
            Destroy(cube.gameObject);
            return;
        }
        
        float childScale = cube.transform.localScale.x *  _splitScaleMultiplier;
        float childSplitChance = cube.SplitChance * _splitChanceMultiplier;
        int childrenCount = Random.Range(_minSplitParts, _maxSplitParts + 1);
        
        Vector3 spawnPosition = cube.transform.position;
        Quaternion spawnRotation = cube.transform.rotation;

        for (int childIndex = 0; childIndex < childrenCount; ++childIndex)
        {
            CubeInitializer child = Instantiate(_cubePrefab, spawnPosition, spawnRotation);
            child.SetChance(childSplitChance);
            child.transform.localScale = new Vector3(childScale, childScale, childScale);
            child.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, spawnPosition, _explosionRadius);
        }
        
        Destroy(cube.gameObject);
    }
}
