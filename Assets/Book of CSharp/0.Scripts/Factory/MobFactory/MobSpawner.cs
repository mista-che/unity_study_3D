using UnityEngine;
using Pattern.Factory;

public abstract class MobSpawner : MonoBehaviour
{
    public Mob SpawnMob(string type)
    {
        Mob mob = CreateMob(type);
        return mob;
    }

    protected abstract Mob CreateMob(string type);
}
