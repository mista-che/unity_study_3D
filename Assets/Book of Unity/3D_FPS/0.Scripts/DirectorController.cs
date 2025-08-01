using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorController : MonoBehaviour
{
    private PlayableDirector playable_director;

    public Camera target_camera;

    private void Start()
    {
        playable_director = GetComponent<PlayableDirector>();
        playable_director.Play();
    }

    private void Update()
    {
        if (playable_director.time > playable_director.duration)
        {

            if (Camera.main == target_camera)
            {
                // if timeline is done, and camera is cinemachine camera, return to maincam
                target_camera.GetComponent<CinemachineBrain>().enabled = false;
            }

            // turn off cinemachine camera && director object
            target_camera.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }
}
