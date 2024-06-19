using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axle
    {
        Front,
        Rear
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axle axle;
    }
    public ControlMode control;
    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;
    public Vector3 _centerOfMass;
    public List<Wheel> wheels;

    float moveInput;
    float steerInput;
    private Rigidbody carRb;
     void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
    }

     void Update()
    {
        GetInputs();
        AnimateWheels();
    }
    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }
    
    public void MoveInput(float input)
    {
        moveInput = input;
    }
    public void SteerInput(float input)
    {
        steerInput = input;
    }

    void GetInputs()
    {

        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
    }
    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration *maxAcceleration * Time.deltaTime;
        }
    }
    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if(wheel.axle == Axle.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }
    
    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
           else
        {
                foreach(var wheel in wheels)
                {
                    wheel.wheelCollider.brakeTorque = 0;
                }
            }
        
    }
    
    
    
    void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingCar"))
        {

            PlayerLost();
        }
    }
    public void PlayerLost()
    {
        SceneController.instance.StoreCurrentLevelIndex();
        SceneManager.LoadScene("LoseScreen");
    }

}
