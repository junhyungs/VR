using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Projectile;
    [SerializeField] Transform Transform_ShootPos;
    [SerializeField] float _projectileSpeed;

    private XRGrabInteractable _grabIntractable;

    private void OnEnable()
    {
        _grabIntractable = this.GetComponent<XRGrabInteractable>();
        _grabIntractable.activated.AddListener(Fire);
    }

    private void OnDisable()
    {
        if(_grabIntractable != null)
        {
            _grabIntractable.activated.RemoveListener(Fire);
        }
    }

    public void Fire(ActivateEventArgs args)
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
