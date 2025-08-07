using UnityEngine;
using Pattern.Factory;

public class OrcWarrior : Mob
{
    private void Awake()
    {
        Initialize("Orc Warrior", 100, 18);
    }
}
