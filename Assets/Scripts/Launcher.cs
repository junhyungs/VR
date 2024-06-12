using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Launcher : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Projectiles;
    [SerializeField] Transform Transform_ShootPos;
    [SerializeField] float m_ProjectileSpeed;

    private XRGrabInteractable m_grabInteractable;

    private void OnEnable()
    {
        m_grabInteractable = this.GetComponent<XRGrabInteractable>();
        m_grabInteractable.activated.AddListener(Fire);
    }

    private void OnDisable()
    {
        if(m_grabInteractable != null)
        {
            m_grabInteractable.activated.RemoveListener(Fire);
        }
    }

    public void Fire(ActivateEventArgs args)
    {
        GameObject newObject = Instantiate(Prefab_Projectiles, Transform_ShootPos.position, Transform_ShootPos.rotation);

        if(newObject.TryGetComponent(out Rigidbody rigidbody))
        {
            ApplyForce(rigidbody);
        }
    }

    private void ApplyForce(Rigidbody rigidbody)
    {
        Vector3 force = Transform_ShootPos.forward * m_ProjectileSpeed;
        rigidbody.AddForce(force);
    }
}
