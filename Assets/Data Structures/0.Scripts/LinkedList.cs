using UnityEngine;
using System.Collections.Generic;

public class LinkedList : MonoBehaviour
{
    public LinkedList<int> linked_list = new();
    public string print_string;

    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            linked_list.AddFirst(i);
        }

        foreach (int i in linked_list)
        {
            print_string = print_string + i.ToString() + ", ";
        }
        Debug.Log(print_string);
    }
}
