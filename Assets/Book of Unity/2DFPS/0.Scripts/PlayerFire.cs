using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firing_position;
    public GameObject bullet_prefab;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bullet_prefab, firing_position.transform.position, firing_position.transform.rotation);
            // transform.SetPositionAndRotation(firing_position.transform.position, firing_position.transform.rotation);
        }
    }
}
