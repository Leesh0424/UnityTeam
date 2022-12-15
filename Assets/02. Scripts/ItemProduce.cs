using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProduce : MonoBehaviour
{
    public Transform itempos;

    [SerializeField] List<Transform> pos = new List<Transform>();

    Transform GetRandompos()
    {
        return pos[Random.Range(0, pos.Count)];
    }
    void Start()
    {
        itempos = GetRandompos();
        transform.position = itempos.position;
    }
}
