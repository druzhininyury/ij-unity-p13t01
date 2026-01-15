using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeParameters : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    public float SplitChance
    {
        get => _splitChance;
        private set => _splitChance = value;
    }
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Initialize(new Vector3(1f, 1f, 1f), _splitChance);
    }

    public void Initialize(Vector3 scale, float splitChance)
    {
        transform.localScale = scale;
        SplitChance = splitChance;
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        block.SetColor("_Color", Random.ColorHSV());
        _renderer.SetPropertyBlock(block);
    }
}
