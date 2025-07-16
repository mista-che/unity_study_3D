using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public enum RodType { LEFT, MIDDLE, RIGHT };
    public RodType type;

    public Stack<GameObject> rod_stack = new();

    private void OnMouseDown()
    {
        if (!HanoiTower.is_selected)
        {
            HanoiTower.is_selected = true;
            HanoiTower.selected_donut = PopDonut();
        }
        else
        {
            PushDonut(HanoiTower.selected_donut);
        }
    }
    public bool CheckDonut(GameObject donut)
    {
        if (rod_stack.Count > 0)
        {
            int push_number = donut.GetComponent<Donut>().number;

            GameObject peek_donut = rod_stack.Peek();
            int peek_number = peek_donut.GetComponent<Donut>().number;

            if (push_number < peek_number)
            {
                return true; // if current peek is bigger
            }
            else
            {
                Debug.LogError($"You can't move a donut of size {push_number} on top of a {peek_number}.");
                return false;
            }
        }
        return true; // if empty
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
        {
            return;
        }
        else
        {
            // reset selection
            HanoiTower.is_selected = false;
            HanoiTower.selected_donut = null;

            // move donut to self (rod)
            donut.transform.position = transform.position + Vector3.up * 3f;
            // donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            // donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            // I should be okay without these as I turned off rotation in the rigidbody

            rod_stack.Push(donut);
        }

    }

    public GameObject PopDonut()
    {
        return rod_stack.Pop();
    }
}
