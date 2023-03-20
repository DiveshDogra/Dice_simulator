using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePhysics : MonoBehaviour
{
   /* [SerializeField]
    private List<Quaternion> _initalRotations;*/

    [SerializeField]
    private Vector3 force;
    [SerializeField]
    private Vector3 angelforce;

    private Quaternion _startRotation;
    private Vector3 _startPos;

    [SerializeField]
    private int roll;

    [SerializeField]
    private List<GameObject> child;
    private Rigidbody _rigidbody;

    [SerializeField]
    private DiceData _diceData;

    private int PreRollValue;
    private void Start()
    { 
        _startRotation = transform.rotation;
        _startPos = transform.position;
        Physics.autoSimulation = false;
        _rigidbody = GetComponent<Rigidbody>();
        SimlulateDice();
    }

    private void SimlulateDice()
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
        _rigidbody.angularVelocity = angelforce;
        for (int i = 0; i < 500; i++)
        {
            Physics.Simulate(Time.fixedDeltaTime);
        }

        CheckDiceFace();

        ResetDice();

        ChangeIntialRotation();

        ThrowDice();
    }

    private void CheckDiceFace()
    {
        foreach(GameObject thischild in child)
        {
            if(thischild.transform.position.y > 1.5)
            {
                PreRollValue = int.Parse(thischild.name);
                Debug.Log(PreRollValue);
            }
        }
    }
    private void ResetDice()
    {
        transform.position = _startPos;
        transform.rotation = _startRotation;
    }

    private void ChangeIntialRotation()
    {
        transform.rotation = (_diceData.faceRelativeRotation[roll].rotation[PreRollValue]);
    }

    private void ThrowDice()
    {
        Physics.autoSimulation = true;
        _rigidbody.AddForce(force, ForceMode.Impulse);
        _rigidbody.angularVelocity = angelforce;
    }
}
