using UnityEngine;

public class FPS_PlayerFire : MonoBehaviour
{
    public GameObject firing_position;
    public GameObject frag_prefab;

    public float throw_power = 15f;

    public GameObject bullet_hit_vfx;
    public ParticleSystem particle_system;

    public enum WeaponMode { RIFLE, SNIPER }
    public WeaponMode current_weapon;



    private void Start()
    {
        particle_system = bullet_hit_vfx.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button
        {
            // shoot ray from main camera, direction: forward
            Ray raycast = new(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit_info = new();

            // there are 16 overloads for Physics.Raycast (you can use Rays or Vectors, they are similar in function)
            // note: Vector3 is used both for transform.position (single point) and direction (unit vector)
            if (Physics.Raycast(raycast, out hit_info))
            {
                // play bullet hit vfx if our bullet hits a target
                bullet_hit_vfx.transform.position = hit_info.point;
                particle_system.Play();
            }
        }
        if (Input.GetMouseButtonDown(1)) // right mouse button
        {
            // makes frag at firing_position
            GameObject frag = Instantiate(frag_prefab);
            frag.transform.position = firing_position.transform.position;

            // throws frag forward
            Rigidbody rb = frag.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throw_power, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_weapon = WeaponMode.RIFLE;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_weapon = WeaponMode.SNIPER;
        }
    }
}
