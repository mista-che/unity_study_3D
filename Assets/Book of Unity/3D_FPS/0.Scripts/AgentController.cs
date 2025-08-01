using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(points[index].position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, points[index].position) < 5f)
        {
            index++;
            if (index >= points.Length)
            {
                index = 0;
            }
            agent.SetDestination(points[index].position);
        }
        StartCoroutine(PrintDestination());
    }

    private IEnumerator PrintDestination()
    {
        Debug.Log($"Current destination is point {index}");
        yield return new WaitForSeconds(2f);
    }
}

