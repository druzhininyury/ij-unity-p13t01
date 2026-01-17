using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    private readonly int _minSplitParts = 2;
    private readonly int _maxSplitParts = 6;

    private readonly float _splitScaleMultiplier = 0.5f;
    private readonly float _splitChanceMultiplier = 0.5f;

    public List<Splittable> Split(Splittable splittable)
    {
        bool isSplitRollSuccess = Random.value < splittable.SplitChance;
        
        List<Splittable> result = new List<Splittable>();

        if (isSplitRollSuccess == false)
        {
            Destroy(splittable.gameObject);
            return result;
        }
        
        Vector3 spawnPosition = splittable.transform.position;
        Quaternion spawnRotation = splittable.transform.rotation;
        Vector3 spawnScale = splittable.transform.localScale * _splitScaleMultiplier;
        float childSplitChance = splittable.SplitChance * _splitChanceMultiplier;
        int childrenCount = Random.Range(_minSplitParts, _maxSplitParts + 1);

        for (int childIndex = 0; childIndex < childrenCount; ++childIndex)
        {
            Splittable child = Instantiate(splittable, spawnPosition, spawnRotation);
            child.Initialize(spawnScale, childSplitChance);
        }
        
        Destroy(splittable.gameObject);
        return result;
    }
}
