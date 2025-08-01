using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SignalEvents : MonoBehaviour
{
    public PlayableDirector timeline;
    public SignalReceiver signal_receiver;
    public SignalAsset signal_message;

    private void Start()
    {
        SetSignalEvent();
    }

    public void SetSignalEvent()
    {
        // adds debug message to empty event container using lambda notation
        UnityEvent event_container = new UnityEvent();
        event_container.AddListener(() => Debug.Log("Event!"));

        // then adds signal reaction to our thingy
        signal_receiver.AddReaction(signal_message, event_container);
    }
}
