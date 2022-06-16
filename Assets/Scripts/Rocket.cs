using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Projectile Data")]
    public int power = 10;
    public int radius = 5;
    public float upForce = 1.0f;
    public float lifeTimer;
    public int projectileSpeed = 5;
    public float explosionTime;
    public GameObject pivot;

    private Vector3 _prevPos;
    private GameObject _player;

    void Start()
    {
        transform.position = pivot.transform.position;
        transform.forward = pivot.transform.forward;
        transform.rotation = Quaternion.LookRotation(pivot.transform.forward);
        _prevPos = transform.position;
        _player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), _player.GetComponent<Collider>());
    }

    void Update()
    {
        _prevPos = transform.position;
        transform.position += -transform.forward * projectileSpeed * Time.deltaTime;
        RaycastHit[] hits = Physics.RaycastAll(new Ray(_prevPos, (transform.position - _prevPos).normalized), (transform.position - _prevPos).magnitude);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
            Explode();
        }
        Debug.DrawLine(transform.position, _prevPos);

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        KnockBack();
        Destroy(gameObject);
    }

    private void KnockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rigidBody = nearby.GetComponent<Rigidbody>();
            if (rigidBody != null && nearby != nearby.CompareTag("Rocket"))
            {
                rigidBody.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
            }

            //Enemy

            //if (nearby.CompareTag("Guardian"))
            //{
            //    nearby.GetComponent<Guardian>().hp -= 1;
            //}
        }
    }
}

