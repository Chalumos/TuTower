using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    public float range = 15f;

    public string ennemyTag = "Enemy";

    public Transform partToRotate;

    private float turnSpeed = 6.5f;
    
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // toute les 0.5s on execute la fonction UpdateTarget
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);       //Lerp() faire des fondus => ici la ratation tourelle
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;  //eulerAngles => c'est le mix x/y/z
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // pour faire la rotation

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(ennemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnnemy < shortestDistance)
            {
                shortestDistance = distanceToEnnemy;
                nearestEnnemy = enemy;
            }
        }

        if( nearestEnnemy != null && shortestDistance <= range)
        {
            target = nearestEnnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
}
