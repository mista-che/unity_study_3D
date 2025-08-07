using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{
    public Queue<GameObject> object_queue = new();

    public GameObject prefab;
    public Transform parent;


}
