using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Fire : MonoBehaviour
{
    [Header("ShootPos")]
    [SerializeField] private Transform ShootPos;

    [Header("BulletSpeed")]
    [SerializeField] private float bulletSpeed;

    private XRGrabInteractable _grabInteractable;

    private void OnEnable()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _grabInteractable.activated.AddListener(Shoot);
    }

    private void OnDisable()
    {
        if(_grabInteractable != null)
        {
            _grabInteractable.activated.RemoveListener(Shoot);
        }
    }

    public void Shoot(ActivateEventArgs args)
    {
        GameObject bullet = BulletPool.Instance.GetBullet();

        bullet.transform.position = ShootPos.position;

        if (bullet.TryGetComponent(out Rigidbody rigid))
        {
            AddForceBullet(rigid);  
        }
    }

    public void ButtonShoot()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();

        bullet.transform.position = ShootPos.position;

        if (bullet.TryGetComponent(out Rigidbody rigid))
        {
            AddForceBullet(rigid);
        }

    }

    private void AddForceBullet(Rigidbody rigid)
    {
        Vector3 force = ShootPos.forward * bulletSpeed;
        rigid.AddForce(force);
    }
}
