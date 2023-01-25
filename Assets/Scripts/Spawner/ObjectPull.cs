using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPull : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pull = new List<GameObject>();

    protected void Initialize(GameObject[] predab) 
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomNumber = Random.Range(0, predab.Length);
            GameObject spawned = Instantiate(predab[randomNumber], _container.transform);
            spawned.SetActive(false);

            _pull.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pull.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
