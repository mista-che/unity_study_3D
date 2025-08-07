using UnityEngine;
using Pattern.Factory;

public class Goblin : Mob
{
    private void Awake()
    {
        Initialize("Goblin", 30, 10);
    }
}
