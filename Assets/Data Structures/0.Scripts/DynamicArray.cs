using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    private object[] array = new object[3];

    void Add(object o)
    {
        // check if array is long enough

        // if not, create new temp array
        var temp = new object[array.Length + 1];

        // add existing elements to new temp array
        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[i];
        }

        // assign temp array values to existing array
        array = temp;

        // add new value
        array[array.Length - 1] = o;
    }

    // DynamicArrays are just called Lists here
    [SerializeField] private List<int> list1 = new();
    [SerializeField] private List<int> list2 = new() { 1, 2, 3, 4, 5 };

    private void Start()
    {
        list2.Add(6);
        list1.Add(1);
        list1.Clear();
    }
}