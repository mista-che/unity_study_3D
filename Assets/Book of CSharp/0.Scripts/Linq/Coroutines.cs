using UnityEngine;
using System.Collections;

public class Coroutines : MonoBehaviour
{
    private IEnumerator enumerator;

    private void Start()
    {
        enumerator = NextNumber();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enumerator.MoveNext();
            if (enumerator.Current == null)
            {
                enumerator = NextNumber();
                enumerator.MoveNext();
            }
            var result = enumerator.Current;
            Debug.Log(result);
        }
    }

    IEnumerator NextNumber()
    {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return null;
    }    
}
