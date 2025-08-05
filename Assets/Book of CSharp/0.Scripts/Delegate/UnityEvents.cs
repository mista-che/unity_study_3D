using UnityEngine;
using UnityEngine.Events;

public class UnityEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent unity_event;

    private void Start()
    {
        unity_event.AddListener(PrintMessage);
        unity_event.RemoveListener(PrintMessage); // or RemoveAllListeners()

        unity_event.AddListener(PrintMessage);
        unity_event.Invoke();
    }

    public void PrintMessage()
    {
        Debug.Log("Message");
    }
}
