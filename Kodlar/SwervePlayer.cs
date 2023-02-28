using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwervePlayer : MonoBehaviour
{
    [SerializeField]
    float forwardSpeed,horizontalSpeed,swerveLimit, thresHold,resetTime,sensivity;

    private float distanceX = 0f;
    private float lastLocation,swerveAmount;
    Vector3 swerveInput;
    Rigidbody moveWithRigidbody;
    ManageGameScript manageGameScript;
    private void Start()
    {
        manageGameScript = GameObject.Find("GameManagerObject").GetComponent<ManageGameScript>();
        moveWithRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(!manageGameScript.isFinish())
            Swerve();
    }
    private void FixedUpdate()
    {
        if (!manageGameScript.isFinish())
            movementChar();
    }

    void Swerve()
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    swerveInput = Vector3.zero;
                    lastLocation = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    distanceX = touch.position.x - lastLocation;
                    swerveAmount = Mathf.Clamp(distanceX*sensivity * Time.fixedDeltaTime, -swerveLimit, swerveLimit);
               
                    swerveInput = new Vector3(swerveAmount, 0, 0);

                    lastLocation = touch.position.x;
                    break;
                case TouchPhase.Stationary:
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    StartCoroutine(resetSwerveInput());
                    break;

            }
        }
    }

    IEnumerator resetSwerveInput()
    {
        while (swerveInput.magnitude > 0.1f)
        {
            swerveInput = Vector3.Lerp(swerveInput, Vector3.zero, resetTime * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        swerveInput = Vector3.zero;          
    }

    public void movementChar()
    {
        Vector3 _verticalMovement;
        Vector3 _horizontalMovement = Vector3.zero;
        
        if ((swerveInput.x < -thresHold || swerveInput.x > thresHold))
            _horizontalMovement = swerveInput * horizontalSpeed;

        if (moveWithRigidbody.position.x + _horizontalMovement.x > 4.5f || moveWithRigidbody.position.x + _horizontalMovement.x < -4.5f)
            _horizontalMovement.x = 0;
        
        _verticalMovement = transform.forward * forwardSpeed * Time.deltaTime;
        Vector3 _finalMovement = _verticalMovement + _horizontalMovement;
        
        moveWithRigidbody.MovePosition(moveWithRigidbody.position + _finalMovement);
    }

}
