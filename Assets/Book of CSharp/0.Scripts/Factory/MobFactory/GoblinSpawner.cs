using Pattern.Factory;
using UnityEngine;

public class GoblinSpawner : MobSpawner
{
    protected override Mob CreateMob(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Goblin").AddComponent<Goblin>();
            case "Warrior":
                return new GameObject("Goblin Warrior").AddComponent<GoblinWarrior>();
            case "Archer":
                return new GameObject("Goblin Archer").AddComponent<GoblinArcher>();
            default:
                Debug.LogError($"Incorrect monster type: {type}.");
                break;

        }
        return null;
    }
}
