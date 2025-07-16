using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firing_position_left;
    public GameObject firing_position_right;
    public GameObject bullet_prefab;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet_prefab, firing_position_left.transform.position, firing_position_left.transform.rotation);
            Instantiate(bullet_prefab, firing_position_right.transform.position, firing_position_right.transform.rotation);
        }
    }
}
