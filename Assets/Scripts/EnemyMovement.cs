using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
    private Vector3 direction;
	private int waypointIndex = -1;

	void Start()
	{
        GetNextWaypoint();
	}

	void Update()
	{
		transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
	}

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length -1 )
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
        direction = (target.position - transform.position).normalized;
    }
}
