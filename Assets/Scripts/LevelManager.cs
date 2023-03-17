using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] startObjects;
    private List<GameObject> _currentObjects = new List<GameObject>();
    public Transform creatingPosition;

    public void ClonStart()
    {
        foreach (GameObject element in startObjects)
        {
            GameObject currentElement = Instantiate(element, creatingPosition) as GameObject;
            element.SetActive(false);
            _currentObjects.Add(currentElement);
        }
    }

    public void CleanLevelObjects()
    {
        for (int i = 0; i < _currentObjects.Count; i++)
        {
            if (_currentObjects[i] != null)
            {
                Destroy(_currentObjects[i]);
            }
        }
        _currentObjects.Clear();
    }

    public void AddInLevelObjects(GameObject element)
    {
        _currentObjects.Add(element);
    }

    void Awake()
    {
        ClonStart();
    }

    void Update()
    {

    }
}
