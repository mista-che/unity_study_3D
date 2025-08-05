using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class Parameters : MonoBehaviour
{
    private int number;

    private void Start()
    {
        number = 1;

        Debug.Log($"NormalParameter(number): {NormalParameter(number)}, number: {number}"); // 10, 1

        number = 1;

        Debug.Log($"DefaultParameter(number): {DefaultParameter(number)}, number: {number}"); // 1, 1
        Debug.Log($"DefaultParameter(): {DefaultParameter()}, number: {number}"); // 3, 1

        number = 1;

        Debug.Log($"ReferenceParameter(number): {ReferenceParameter(ref number)}, number: {number}"); // 10, 10

        number = 1;

        Debug.Log($"OutParameter(number): {OutParameter(out number)}, number: {number}"); // 10, 10
        
    }

    // call by value
    private int NormalParameter(int a)
    {
        a = 10;
        return a;
    }

    private int DefaultParameter(int a = 3)
    {
        return a;
    }

    // call by reference
    private int ReferenceParameter(ref int a)
    {
        a = 10; // changes "private int number" alongside returning a
        return a;
    }

    private int OutParameter(out int a) // this param input can be uninitialized.
    {
        // out WRITES to the referenced variable, but cannot READ it (is never sent the data)
        // out MUST assign values to the parameters, because they are uninitialized (because the original data is never sent)
        a = 10; // compiler error if this is removed
        return a;
    }

    private int Params(params int[] a) // "params" allows the "array" component of the call to be OPTIONAL.
        // you can pass no values, or a list of ints (1, 2, 3, 4, 5) instead of initializing an array and passing it.
        // not using params REQUIRES an array to be passed
        // note: when using params, put it at the end of the list of parameters (everything after the "params" is considered optional)
    {
        int sum = 0;
        foreach (var i in a)
            sum += i;
        return sum;
    }
}
