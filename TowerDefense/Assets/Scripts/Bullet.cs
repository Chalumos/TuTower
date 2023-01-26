using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position; // notre pos - pos de la cible
        float distanceThisFrame = speed * Time.deltaTime;  

        if(direction.magnitude <= distanceThisFrame) // si balle presque arrive
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);  //bouger à même vitesse 
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
