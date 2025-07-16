using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float current_time;
    public float spawn_interval = 1f;
    private float interval_min = 1f;
    private float interval_max = 3f;

    private float x_bound = 8f;
    private bool facing_right = true;
    private float movement_speed = 0.1f;

    public GameObject enemy_prefab;

    private void Start()
    {
        spawn_interval = Random.Range(interval_min, interval_max);
    }

    private void Update()
    {
        current_time += Time.deltaTime;

        if (current_time > spawn_interval)
        {
            GameObject enemy = Instantiate(enemy_prefab, transform.position, Quaternion.identity);

            current_time = 0f;
        }

        // facing_right until x=8f
    }

    private void FixedUpdate()
    {
        //if (facing_right)
        //    transform.position += Vector3.right * movement_speed;
        //else
        //    transform.position += Vector3.left * movement_speed;
    }
}
