using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float TimeBetweenShoot = .3f;
    public Transform playerSideReference;

    private Coroutine _currentCorroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCorroutine = StartCoroutine(StarShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCorroutine != null)
                StopCoroutine(_currentCorroutine);
        }
    }

    IEnumerator StarShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(TimeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }

}
