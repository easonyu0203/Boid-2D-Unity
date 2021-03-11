using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMovement : MonoBehaviour
{
    [SerializeField] FloatVariable _forwardSpeed;
    [SerializeField] FloatVariable _turnSpeed;
    [SerializeField] FloatVariable _viewRadius;
    [SerializeField] ListGameObjectVariable _fishesList;

    [SerializeField] FloatVariable _weightforward;
    [SerializeField] FloatVariable _weightCohesion;
    [SerializeField] FloatVariable _weightSeparation;
    [SerializeField] FloatVariable _weightAlignment;


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

        //rotate toward velocity direction
        FaceFront();
    }

    Vector2 CalculateVelocity()
    {
        List<GameObject> neighboringFish_list = GetNeighboringFishList();

        //adding all velocity of all rules
        Vector2 velocity = (
            _weightforward.Value * (Vector2)_transform.right
            + _weightCohesion.Value * Rule1(neighboringFish_list)
            + _weightSeparation.Value * Rule2(neighboringFish_list)
            + _weightAlignment.Value * Rule3(neighboringFish_list)
        ).normalized * _forwardSpeed.Value;
        return velocity;
    }

    //rotate the fish to current velocity
    void FaceFront()
    {
        float step = Time.fixedDeltaTime * _turnSpeed.Value;
        Vector3 newDir = Vector3.RotateTowards(_transform.right, _rigidbody2D.velocity, step, 0);

        float zOffset = Vector2.SignedAngle(_transform.right, newDir);
        _transform.Rotate(Vector3.forward, zOffset);
    }

    List<GameObject> GetNeighboringFishList()
    {
        List<GameObject> neighboringFish_list = new List<GameObject>();

        //get neghboring fish
        foreach (GameObject fish in _fishesList.Value)
        {
            //don't include itself
            if (fish == this.gameObject) continue;

            if (Vector2.Distance(_transform.position, fish.transform.position) <= _viewRadius.Value)
            {
                neighboringFish_list.Add(fish);
            }
        }
        return neighboringFish_list;
    }

    #region Rule1_Defination

    //Boid rule 1: Boids try to fly towards the centre of mass of neighbouring boids.
    //return the direction of this rule
    Vector2 Rule1(List<GameObject> neighboringFish_list)
    {
        Vector2 direction = new Vector2();


        //get centrol position
        Vector2 centerPos = Vector2.zero;
        foreach (var fish in neighboringFish_list)
        {
            centerPos += (Vector2)fish.transform.position;
        }
        if (neighboringFish_list.Count != 0)
        {
            centerPos /= neighboringFish_list.Count;
        }
        else
        {
            centerPos = _transform.position;
        }

        //get direction
        direction = (centerPos - (Vector2)this.transform.position).normalized;


        return direction;
    }

    #endregion

    #region Rule2_Defination
    //Rule 2: Boids try to keep a small distance away from other objects(including other boids).
    Vector2 Rule2(List<GameObject> neighboringFish_list)
    {
        Vector2 direction = Vector2.zero;

        foreach (var fish in neighboringFish_list)
        {
            Vector2 awayFishVec = (Vector2)_transform.position - (Vector2)fish.transform.position;
            //the closer the bigger weight it get
            float x = awayFishVec.magnitude / _viewRadius.Value;
            float weight = 1;

            direction += awayFishVec.normalized * weight;
        }
        direction.Normalize();

        return direction;
    }
    #endregion

    #region Rule3_Defination
    Vector2 Rule3(List<GameObject> neighboringFish_list)
    {
        Vector2 direction = new Vector2();

        Vector2 centrolVelocity = Vector2.zero;
        foreach (var fish in neighboringFish_list)
        {
            centrolVelocity += fish.GetComponent<Rigidbody2D>().velocity;
        }
        if (neighboringFish_list.Count != 0)
        {
            centrolVelocity /= neighboringFish_list.Count;
        }
        else
        {
            centrolVelocity = _rigidbody2D.velocity;
        }
        direction = centrolVelocity.normalized;

        return direction;
    }
    #endregion
}
