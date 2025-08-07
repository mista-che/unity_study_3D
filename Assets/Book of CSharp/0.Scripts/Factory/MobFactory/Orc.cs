using UnityEngine;
using Pattern.Factory;

public class Orc : Mob
{
    private void Awake()
    {
        Initialize("Orc", 40, 12);
    }
}
