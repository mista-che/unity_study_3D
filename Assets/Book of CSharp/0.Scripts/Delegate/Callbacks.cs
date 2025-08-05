using System;
using System.Collections;
using UnityEngine;

public class Callbacks : MonoBehaviour
{
    public Action callback;

    private void OnEnable()
    {
        callback += () =>
        {
            Charge();
            Fire();
            Damage();
        };
    }

    IEnumerator Start()
    {
        Debug.Log("Start(): timer");
        yield return new WaitForSeconds(3f);

        callback.Invoke();
    }

    private void Charge()
    {
        Debug.Log("Charging my lazor!");
    }

    private void Fire()
    {
        Debug.Log("Firin' my lazor!");
    }

    private void Damage()
    {
        Debug.Log("The lazor's doin' some serious damage!");
    }
}
