using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Projectile;
    [SerializeField] Transform Transform_ShootPos;
    [SerializeField] float _projectileSpeed;

    public void Fire()
    {
        GameObject newObj = Instantiate(Prefab_Projectile, Transform_ShootPos.position, Transform_ShootPos.rotation);
        if(newObj.TryGetComponent(out Rigidbody rigidBody))
        {
            ApplyForce(rigidBody);
        }
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = Transform_ShootPos.forward * _projectileSpeed;
        rigidBody.AddForce(force);
    }
}
