using UnityEngine;

public class Singletons : MonoBehaviour
{
    // singletons are unique classes (i.e. only one instance may exist at any time)
    // this means that they can be called by classname (i.e. Singleton.DoSomething()) rather than an instanced variable name (Singleton singleton, singleton.DoSomething())

    public static Singletons instance;

    public int number;

    private void Start()
    {
        instance = this;
    }
}