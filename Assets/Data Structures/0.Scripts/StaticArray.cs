using Unity.VisualScripting;
using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // arrays look like this: typename[number], i.e. int[7]
    public int[] array_1; // declares an empty array, assigns no space
    public int[] array_2 = { 10, 20, 30, 40, 50 }; // declares an array and populates it with 5 things
    public int[] array_3 = new int[5]; // declares an array of size 5, does not populate
    public int[] array_4 = new int[5] { 10, 20, 30, 40, 50 }; // declares an array of size 5 and populates it with 5 things

    // note. in Unity, you can actually edit arrays inside the engine using the inspector window.
    // this means arrays are slightly more flexible than in other languages / environments

    private void Start()
    {
        int i = array_1[3]; // 3 here is the array index, it gets the 4th element (index counts from 0)
        Debug.Log("array_1[3]: " + array_1[3]);
    }
}
