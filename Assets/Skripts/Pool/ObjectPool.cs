using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _objects;

    protected Queue<T> Objects => _objects;

    private void Awake() => _objects = new Queue<T>();

    public abstract T Get(Vector2 position);

    public abstract void Clear();

    public void Release(T poolObject)
    {
        _objects.Enqueue(poolObject);
        poolObject.gameObject.SetActive(false);
    }
}
