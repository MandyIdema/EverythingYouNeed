using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    //This script goes hand in hand with the Navmesh package! make sure to add a navmesh agent to the gameobject!!

    [Header("--- Movement ---")]
    //======== WANDERING =============

    [Tooltip("Sets the speed")]
    [SerializeField]
    [Range(0.0f, 100.0f)]
    public float speed;

    [Tooltip("Sets the running speed")]
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float runningSpeed;

    public float originalSpeed;

    [Tooltip("Range in which the bunny can detect plants or has to run from a predator")]
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float range;

    [Tooltip("Maximumdistance between the bunny and the predator")]
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float maxDistance;

    Vector2 wayPoint;

    [Header("--- Chasing ---")]

    //========= FOLLOW PASSIVE ============

    private float distance;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    public float distanceBetween;

    //====== AI ======
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;


    void Start()
    {
        SetNewDestination();

        originalSpeed = speed;
    }


    void Update()
    {


        //If the distance is small enough, chase the prey
        //The predator needs to be hungry as well in order to hunt (or else there is no use for hunting)

        if (distance < distanceBetween)
        {
            //old code

            /*transform.position = Vector2.MoveTowards(this.transform.position, Target.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            Attack = true;
            Running();
            Debug.Log("Hunting");*/

            //new code using navmesh

            agent.SetDestination(target.position);
            agent.speed = runningSpeed;
        }
        else
        {
            //If you're not chasing then wander around :)
            Wandering();
            //Debug.Log("Wandering around");
        }

    }

/*    void GenderSpecification()
    {
        if (randomNumber > 50)
        {
            Gender = true; //FEMALE
        }
        else
        {
            Gender = false; // MALE
        }
    }*/

    void Wandering()
    {
        speed = originalSpeed;
        //AI wanders around the map
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

    void Running()
    {

        speed = runningSpeed;

    }


    // (OPTIONAL)

    //Add this if you want the AI to take damage as well
    /*    void TakeDamage()
        {

            if (this.currentHealth <= 0)
            {
                Death();
            }

            if (currentHunger < 0)
            {
                currentHealth -= Damage * Time.deltaTime;
            }

        }*/

    /*    void Death()
        {
            Destroy(this.gameObject);

            //Destroy
            print("I died :(");
        }*/
    /*
        void hungerDecrease()
        {
            currentHunger -= hungryLevel * Time.deltaTime;
        }*/



    /*
        void regenerateEnergy()
        {
            if (currentEnergy < maxEnergy)
            {
                currentEnergy += regenerateStamina * Time.deltaTime;
            }
        }*/

    
    //Old code (this was before I used the navmesh agent. Don't like using the navmesh? enable this code!


    /*   void addPassivetoList()
       {
           foreach (GameObject passive in GameObject.FindGameObjectsWithTag("Player"))
           {
               if (!passiveObjects.Contains(passive))
               {
                   passiveObjects.Add(passive);
               }
           }

       }

       public GameObject FindClosestPassive()
       {
           GameObject[] gos;
           gos = GameObject.FindGameObjectsWithTag("Player");
           GameObject closest = null;
           float distance = Mathf.Infinity;
           Vector3 position = transform.position;
           foreach (GameObject go in gos)
           {
               Vector3 diff = go.transform.position - position;
               float curDistance = diff.sqrMagnitude;
               if (curDistance < distance)
               {
                   closest = go;
                   distance = curDistance;
               }
           }
           return closest;
       }*/
    /*
        private void OnCollisionStay2D(Collision2D collision)
        {
            currentHunger += AttackPower * Time.deltaTime;
        }*/
}
