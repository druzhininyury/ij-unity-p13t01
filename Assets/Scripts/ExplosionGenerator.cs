using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 8f;
    [SerializeField] private float _explosionRadius = 1f;
    public void ExplodeObjects(IEnumerable<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            Rigidbody objectRigidbody = obj.GetComponent<Rigidbody>();

            if (objectRigidbody == null)
            {
                continue;
            }
            
            objectRigidbody.AddExplosionForce(_explosionForce, obj.transform.position, _explosionRadius);
        }
    }
}
