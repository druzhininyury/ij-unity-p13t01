using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 8f;
    [SerializeField] private float _explosionRadius = 1f;
    
    public void ExplodeObjects(IEnumerable<Rigidbody> objects)
    {
        foreach (Rigidbody obj in objects)
        {
            obj.AddExplosionForce(_explosionForce, obj.transform.position, _explosionRadius);
        }
    }
}
