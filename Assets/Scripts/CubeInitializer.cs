using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class CubeInitializer : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    
    public float SplitChance { get; private set; } = 1f;
    
    public void SetChance(float chance)
    {
        SplitChance = chance;
    }
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        block.SetColor("_Color", Random.ColorHSV());
        _renderer.SetPropertyBlock(block);
    }
}
