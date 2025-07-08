using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb_prefab;

    public int range_x = 5;
    public int range_z = 5;
    public int drop_height = 10;

    IEnumerator Start()
    {
        while (true) {
            yield return new WaitForSeconds(1f);
            SpawnBomb();
        }

}

    private void SpawnBomb()
    {
        float random_x = Random.Range(-range_x, range_x);
        float random_z = Random.Range(-range_z, range_z);

        Vector3 random_position = new(random_x, drop_height, random_z);

        Instantiate(bomb_prefab, random_position, Quaternion.identity);
    }
}
