using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerBlue : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolerSize = 10;
    private List<GameObject> _pooler;
    private GameObject _poolerParent;

    private void Awake()
    {
        _pooler = new List<GameObject>();
        _poolerParent = new GameObject($"PoolerParent({prefab.name})");
        CreatePooler();
    }

    private void CreatePooler()
    {
        for (int i = 0; i < poolerSize; i++)
        {
            _pooler.Add(CreateInstance());
        }
    }

    private GameObject CreateInstance()
    {
        GameObject newInstance = Instantiate(prefab);
        newInstance.transform.SetParent(_poolerParent.transform);
        newInstance.SetActive(false);
        return newInstance;
    }

    public GameObject GetInstanceFromPooler()
    {
        for (int i = 0; i < _pooler.Count; i++)
        {
            if (!_pooler[i].activeInHierarchy)
            {
                return _pooler[i];
            }
        }
        return CreateInstance();
    }

    public static void ReturnToPooler(GameObject instance)
    {
        instance.SetActive(false);
    }
}
