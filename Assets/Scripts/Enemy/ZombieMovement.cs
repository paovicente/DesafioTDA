using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {
    [SerializeField] [Range(0.5f,15f)] float speed = 10f;

    [SerializeField] Transform playerTransform;
    
    void Update(){
        typeEnemy();
    }

    public void RotateAroundPlayer(){

        LookPlayer();
        transform.RotateAround(playerTransform.position, Vector3.up, 10f * Time.deltaTime);
    }

    public void ChasePlayer(){

        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);

        if (direction.magnitude >= 2f)
            transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void LookPlayer(){

        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private void typeEnemy(){

        switch(gameObject.name){     //si agregara mas enemigos tendria que usar otra condicion :)
            case "EnemyRobot": 
                ChasePlayer();
            break;
            case "EnemyBoy":
                RotateAroundPlayer();
            break;
            default:
            break;
        }
    }
}
