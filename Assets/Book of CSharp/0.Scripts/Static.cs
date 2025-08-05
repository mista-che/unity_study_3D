using UnityEngine;

public class Static : MonoBehaviour
{
    private static int number;

    private void Start()
    {
        Static.number = 10;
        
    }
}
