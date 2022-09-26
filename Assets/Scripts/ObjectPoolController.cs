using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{

    [SerializeField] GameObject _pooledObjectPrefab;
    [SerializeField] int _numPooledObjects;

    List<GameObject> _objectPool = new List<GameObject>();
    // Start is called before the first frame update

    void GeneratePool()
    {
        for (int i = 0; i < _numPooledObjects; i++)
        {
            GameObject tempGameObject = Instantiate(_pooledObjectPrefab, transform);
            tempGameObject.SetActive(false);
            _objectPool.Add(tempGameObject);

        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _numPooledObjects; i++)
        {
            if (!_objectPool[i].activeInHierarchy)
            {
                return _objectPool[i];
            }
        }
        Debug.Log("Not enough pooled objects, consider increaing");
        return null;
    }
    void Awake()
    {
        GeneratePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
