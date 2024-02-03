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

    public KeyCode keyCode = KeyCode.Z;
    public AudioRandomPlayAudioClips randomShoot;

    private void Awake()
    {
        playerSideReference = GameObject.FindAnyObjectByType<Player>().transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentCorroutine = StartCoroutine(StarShoot());
        }
        else if (Input.GetKeyUp(KeyCode.Z))
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
