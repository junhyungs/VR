using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _activeFalseTime = 3.0f;

    private void OnEnable()
    {
        Invoke(nameof(ReturnBullet), _activeFalseTime);
    }

    private void ReturnBullet()
    {
        gameObject.SetActive(false);
    }
}
