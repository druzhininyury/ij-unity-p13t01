using System.Collections.Generic;
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

    private void UserPointCallback()
    {
        GameObject selectedObject = _selector.GetSelection();

        if (selectedObject == null)
        {
            return;
        }

        List<GameObject> children = _splitter.Split(selectedObject.GetComponent<CubeParameters>());
        _explosionGenerator.ExplodeObjects(children);
    }
}
