using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup SOPlayerSetup;

    //public Animator animator;
    private float _currentSpeed;

    public Animator _currentPlayer;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpVFX;
    public AudioSource audioSourceJump;

    private int _playerDirection = 1;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(SOPlayerSetup.player, transform);

        if(collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }

    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + distToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(SOPlayerSetup.triggerDeath);
    }

    private void Update()
    {
        IsGrounded();
        HandleMoviment();
        HandleJump();
        
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = SOPlayerSetup.speedrun;
            _currentPlayer.speed = 2;
        }
        else
        {
            _currentSpeed = SOPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, SOPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(SOPlayerSetup.boolRun, true);
            _playerDirection = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, SOPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(SOPlayerSetup.boolRun, true);
            _playerDirection = 1;
        }
        else
        {
            _currentPlayer.SetBool(SOPlayerSetup.boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += SOPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= SOPlayerSetup.friction;
        }
    }


    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            myRigidbody.velocity = Vector2.up * SOPlayerSetup.forcejump;
            myRigidbody.transform.localScale = Vector2.one;

            if (tween != null) tween.Kill();
            DOTween.Kill(myRigidbody.transform);
            HandleScaleJump();
            PlayJumpVFX();
        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position);
        if(audioSourceJump != null) audioSourceJump.Play();
    }

    Tweener tween;
    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(SOPlayerSetup.jumpScaleY, SOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
        tween = DOTween.To(ScaleXGetter, ScaleXSetter, SOPlayerSetup.jumpScaleX, SOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
    }

    private float ScaleXGetter()
    {
        return myRigidbody.transform.localScale.x;
    }

    private void ScaleXSetter(float value)
    {
        var s = myRigidbody.transform.localScale;
        s.x = value * _playerDirection;
        myRigidbody.transform.localScale = s;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
