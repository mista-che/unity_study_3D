using Pattern.Factory;
using UnityEngine;

public class OrcSpawner : MobSpawner
{
    protected override Mob CreateMob(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Orc").AddComponent<Orc>();
            case "Warrior":            
                return new GameObject("Orc Warrior").AddComponent<OrcWarrior>();
            case "Archer":             
                return new GameObject("Orc Archer").AddComponent<OrcArcher>();
            default:
                Debug.LogError($"Incorrect monster type: {type}.");
                break;

        }
        return null;
    }
}
