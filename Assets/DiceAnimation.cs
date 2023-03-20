using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiceAnimation : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Sequence diceSequence;

    [SerializeField]
    private Vector3 _punchPos;
    [SerializeField]
    private Vector3[] rotations;
    [SerializeField]
    private int side;

    private void Start()
    {
        ThrowDice();
    }

    private void ThrowDice()
    {
        diceSequence.Append(transform.DOLocalRotate(rotations[side] , _speed, RotateMode.LocalAxisAdd)).SetRelative();     
        
        diceSequence.Play().SetLoops(-1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        diceSequence.Kill();
    }

}
