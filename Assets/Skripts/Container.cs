using System.Collections.Generic;
using UnityEngine;

public class Container<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<T> _objects;

    private void Awake() => _objects = new List<T>();

    public void Add(T newObject)
    {
        newObject.transform.SetParent(transform);
        _objects.Add(newObject);
    }

    public void Clear()
    {
        foreach (T obj in _objects)
            Destroy(obj);

        _objects.Clear();
    }
}
