using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData[] weapon_data;
    public GameObject[] weapon_objects;

    public string currentweapon_name;
    public int currentweapon_damage;
    public int currentweapon_range;

    private void Start()
    {
        foreach (var data in weapon_data)
        {
            Debug.Log($"{data.weapon_name} / damage: {data.weapon_damage} / range: {data.weapon_range}");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwapWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwapWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SwapWeapon(2);
    }

    private void SwapWeapon(int index)
    {
        foreach (var weapon in weapon_objects)
        {
            weapon.SetActive(false);
        }
        weapon_objects[index].SetActive(true);

        currentweapon_name = weapon_data[index].weapon_name;
        currentweapon_damage = weapon_data[index].weapon_damage;
        currentweapon_range = weapon_data[index].weapon_range;
    }
}
