using UnityEngine;
using Pattern.Factory;

public class GoblinWarrior : Mob
{
    private void Awake()
    {
        Initialize("Goblin Warrior", 70, 15);
    }
}
