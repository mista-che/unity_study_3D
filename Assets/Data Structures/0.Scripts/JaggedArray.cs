using UnityEngine;

public class JaggedArray : MonoBehaviour
{
    // from wikipedia: Jagged arrays are "an array of arrays of which the member arrays can be of different lengths, producing rows of jagged edges when visualized as output."
    public int[] array_1 = new int[3];
    public int[][] jagged_array = new int[3][]; // declares a jagged array that holds 3 int arrays

    private void Start()
    {
        array_1[0] = 1;
        array_1[1] = 2;
        array_1[2] = 3;

        // like multi-dimentional arrays, these values are not displayed in the Unity inspector
        jagged_array[0] = new int[2] { 0, 1 };
        jagged_array[1] = new int[3] { 7, 8, 9 };
        jagged_array[2] = new int[5] { 1, 2, 3, 4, 5 };
    }
}
