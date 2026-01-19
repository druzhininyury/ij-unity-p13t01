using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Selector _selector;
    [SerializeField] private Splitter _splitter;
    [SerializeField] private ExplosionGenerator _explosionGenerator;

    private void OnEnable()
    {
        _inputReader.UserPointAction += UserPointCallback;
    }

    private void OnDisable()
    {
        _inputReader.UserPointAction -= UserPointCallback;
    }

    private void UserPointCallback(Vector3 inputPosition)
    {
        Splittable selectedSplittable = _selector.GetSelection(inputPosition);

        if (selectedSplittable == null)
        {
            return;
        }

        bool isSplitRollSuccess = Random.value < selectedSplittable.SplitChance;

        if (isSplitRollSuccess)
        {
            List<Splittable> children = _splitter.Split(selectedSplittable);
            _explosionGenerator.ExplodeObjects(children.Select(child => child.Rigidbody));
        }
        else
        {
            _explosionGenerator.ExplodeAll(selectedSplittable.transform);
        }
        
        Destroy(selectedSplittable.gameObject);
    }
}
