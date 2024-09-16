using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _freeObjects;
    private List<T> _allObjects;

    public event Action Released;

    protected Queue<T> FreeObjects => _freeObjects;
    protected List<T> AllObjects => _allObjects;

    private void Awake()
    {
        _freeObjects = new Queue<T>();
        _allObjects = new List<T>();
    }

    public abstract T Get(Vector2 position);

    public void Release(T poolObject)
    {
        _freeObjects.Enqueue(poolObject);
        poolObject.gameObject.SetActive(false);
        Released?.Invoke();
    }
}
