using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public float impactEffectTimeToLive = 2f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

	private void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);
    }

    private void HitTarget()
    {
        GameObject effectGO = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectGO, impactEffectTimeToLive);

        Destroy(target.gameObject);

        Destroy(gameObject);
    }
}
