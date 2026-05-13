using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private Stack<T> _pool;
    private List<T> _allObjects;

    private void Awake()
    {
        _pool = new Stack<T>();
        _allObjects = new List<T>();
    }

    public T GetObject()
    {
        T newObject;

        if (_pool.Count == 0)
        {
            newObject = Instantiate(_prefab,_container);
            _allObjects.Add( newObject );
        }
        else
        {
            newObject = _pool.Pop();
            newObject.gameObject.SetActive(true);
        }

        return newObject;
    }

    public void ReturnToPool(T newObject)
    {
        newObject.gameObject.SetActive(false);
        _pool.Push( newObject );
    }

    public void Reset()
    {
        foreach( T item in _allObjects )
        {
            if (item.gameObject.activeSelf)
            {
                ReturnToPool(item);
            }
        }
    }
}