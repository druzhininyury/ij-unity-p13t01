using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Splittable : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    
    private readonly int _colorId = Shader.PropertyToID("_Color");
    
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    public Rigidbody Rigidbody { get; private set; }
    
    public float SplitChance
    {
        get => _splitChance;
        private set => _splitChance = value;
    }
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Initialize(new Vector3(1f, 1f, 1f), _splitChance);
        
        Rigidbody = GetComponent<Rigidbody>();
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
        block.SetColor(_colorId, Random.ColorHSV());
        _renderer.SetPropertyBlock(block);
    }
}
