using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    [SerializeField] private float _targetExplosionForce = 8f;
    [SerializeField] private float _targetExplosionRadius = 1f;

    [SerializeField] private float _baseGlobalExplostionRadius = 5f;
    [SerializeField] private float _baseGlobalForceMultiplier = 50f;

    private float _maxObjectDimension = 10f;
    
    public void ExplodeObjects(IEnumerable<Rigidbody> objects)
    {
        foreach (Rigidbody obj in objects)
        {
            obj.AddExplosionForce(_targetExplosionForce, obj.transform.position, _targetExplosionRadius);
        }
    }

    public void ExplodeAll(Transform objectTransform)
    {
        float objectDimension = Math.Min(objectTransform.localScale.magnitude, _maxObjectDimension);
        float explosionRadius = _baseGlobalExplostionRadius + 1f / objectDimension;
        float explosionForce = Mathf.Pow(1f / objectDimension, 2f) * _baseGlobalForceMultiplier;

        List<Rigidbody> involvedObjects = Physics.OverlapSphere(objectTransform.position, explosionRadius)
            .Select(collider => collider.GetComponent<Splittable>())
            .Where(splittable => splittable != null)
            .Select(splittable => splittable.Rigidbody)
            .ToList();

        foreach (Rigidbody objectRigidbody in involvedObjects)
        {
            objectRigidbody.AddExplosionForce(explosionForce, objectTransform.position, explosionRadius);
        }
    }
}
