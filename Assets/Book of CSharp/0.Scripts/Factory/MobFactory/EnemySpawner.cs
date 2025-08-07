using UnityEngine;
using Pattern.Factory;

public class EnemySpawner : MonoBehaviour
{
    private MobSpawner current_spawner;
    private Mob current_monster;

    private GoblinSpawner goblin_spawner;
    private OrcSpawner orc_spawner;

    private void Awake()
    {
        goblin_spawner = new GameObject("Goblin Spawner").AddComponent<GoblinSpawner>();
        orc_spawner = new GameObject("Orc Spawner").AddComponent<OrcSpawner>();
    }

    private void Start()
    {
        current_spawner = goblin_spawner;
        current_monster = current_spawner.SpawnMob("Normal");
    }
}
