using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;

    public void Start()
    {
        target = Waypoints.points[0]; 
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
       
    }

}
