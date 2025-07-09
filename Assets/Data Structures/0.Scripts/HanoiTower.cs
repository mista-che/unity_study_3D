using System.Collections;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiTower_DifficultyLevel { Lv1 = 3, Lv2, Lv3 }; // this makes the index start at 3, which is the # of donuts
    public HanoiTower_DifficultyLevel hanoi_level;

    public GameObject indicator;
    public Material indicator_white;
    public Material indicator_yellow;

    public GameObject[] donut_prefabs; // 1 2 3 4 5 increasing size
    public Rod[] rod_stacks; // left middle right

    private Vector3 drop_position_left = new(-2.5f, 3f, 0);
    private Vector3 drop_position_middle = new(0f, 3f, 0);
    private Vector3 drop_position_right = new(2.5f, 3f, 0);

    public static bool is_selected;
    public static GameObject selected_donut;

    IEnumerator Start()
    {
        for (int i = (int)hanoi_level - 1; i >= 0; i--)
        {
            GameObject donut = Instantiate(donut_prefabs[i]);

            donut.transform.position = drop_position_left;

            rod_stacks[0].PushDonut(donut);

            yield return new WaitForSeconds(0.75f);
        }
    }

    private void Update()
    {
        if (is_selected)
            indicator.GetComponent<MeshRenderer>().material = indicator_yellow;
        else
            indicator.GetComponent<MeshRenderer>().material = indicator_white;
    }
}
