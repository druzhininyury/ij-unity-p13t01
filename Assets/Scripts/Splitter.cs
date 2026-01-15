using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    private readonly int _minSplitParts = 2;
    private readonly int _maxSplitParts = 6;

    private readonly float _splitScaleMultiplier = 0.5f;
    private readonly float _splitChanceMultiplier = 0.5f;

    public List<GameObject> Split(CubeParameters cubeParameters)
    {
        GameObject objectToSplit = cubeParameters.gameObject;
        bool isSplitRollSuccess = Random.value < cubeParameters.SplitChance;
        
        List<GameObject> result = new List<GameObject>();

        if (isSplitRollSuccess == false)
        {
            Destroy(objectToSplit);
            return result;
        }
        
        Vector3 spawnPosition = cubeParameters.transform.position;
        Quaternion spawnRotation = cubeParameters.transform.rotation;
        Vector3 spawnScale = cubeParameters.transform.localScale * _splitScaleMultiplier;
        float childSplitChance = cubeParameters.SplitChance * _splitChanceMultiplier;
        int childrenCount = Random.Range(_minSplitParts, _maxSplitParts + 1);

        for (int childIndex = 0; childIndex < childrenCount; ++childIndex)
        {
            GameObject child = Instantiate(objectToSplit, spawnPosition, spawnRotation);
            child.GetComponent<CubeParameters>().Initialize(spawnScale, childSplitChance);
        }
        
        Destroy(objectToSplit);
        return result;
    }
}
