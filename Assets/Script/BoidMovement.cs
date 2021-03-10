using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMovement : MonoBehaviour
{
    [SerializeField] FloatVariable _forwardSpeed;
    [SerializeField] FloatVariable _turnSpeed;
    [SerializeField] FloatVariable _viewRadius;
    [SerializeField] ListGameObjectVariable _fishesList;

    [SerializeField] BoidMovementWeights _boidWeights;


    private Rigidbody2D _rigidbody2D;
    private Transform _transform;

    void Start()
    {
        //initialize
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    private void FixedUpdate()
    {
        //apply velocity
        _rigidbody2D.velocity = CalculateVelocity();





    }

    Vector3 CalculateVelocity()
    {
        //adding all velocity of all rules
        Vector3 velocity = (
            _boidWeights.weightDefault * _transform.right
            + _boidWeights.weight1 * Rule1()
        ).normalized * _forwardSpeed.Value;
        return velocity;
    }

    //rotate the fish to current velocity
    void FaceFront()
    {

    }

    #region Rule1_Defination

    //Boid rule 1: Boids try to fly towards the centre of mass of neighbouring boids.
    //return the direction of this rule
    Vector3 Rule1()
    {
        Vector3 direction = new Vector3();
        List<GameObject> neighboringFish_list = new List<GameObject>();

        //get neghboring fish
        foreach (GameObject fish in _fishesList.Value)
        {
            //don't include itself
            if (fish == this.gameObject) continue;

            if (Vector3.Distance(_transform.position, fish.transform.position) <= _viewRadius.Value)
            {
                neighboringFish_list.Add(fish);
            }
        }

        //get centrol position
        Vector3 centerPos = Vector3.zero;
        foreach (var fish in neighboringFish_list)
        {
            centerPos += fish.transform.position;
        }
        centerPos /= neighboringFish_list.Count;

        //get direction
        direction = (centerPos - this.transform.position).normalized;

        return direction;
    }

    #endregion
}
