using UnityEngine;

public class DelegateMethods : MonoBehaviour
{
    public delegate void DelegateMethod();
    public DelegateMethod delegate_method;

    public delegate void FuncContainer();
    public FuncContainer func_container;

    private void Start()
    {

        delegate_method = new DelegateMethod(MethodA);
        delegate_method = MethodA;

        if (delegate_method != null) delegate_method.Invoke(); // A
        delegate_method?.Invoke(); // A

        func_container += MethodB;
        func_container.Invoke(); // B

        func_container += MethodC;
        func_container.Invoke(); // B + C

        func_container = MethodA;
        func_container.Invoke(); // A

        func_container += delegate
        {
            MethodC();
            MethodB();
            MethodA();
        };
        func_container.Invoke(); // A+C+B+A

        // why do we use these and lambda functions? some things only work with them (i.e. buttons can only be assigned methods with parameters via nameless method (lambda) or delegates)
    }

    private void MethodA()
    {
        Debug.Log("MethodA() called");
    }

    private void MethodB()
    {
        Debug.Log("MethodB() called");
    }

    private void MethodC()
    {
        Debug.Log("MethodC() called");
    }
}
