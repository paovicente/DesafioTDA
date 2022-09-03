using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {
    [SerializeField] [Range(0.5f,15f)] float speed = 3f;

    [SerializeField] Transform playerTransform;
    
    [SerializeField] ZombieManager manager;

    private void Update() {

        if (manager.ZombieDirectory.ContainsKey(gameObject.name)){    
            zombieController();
        }

    }

    public void zombieController(){

        switch (gameObject.name){
            case "zombieA": ChasePlayer();
            break;
            case "zombieC": RotateAroundPlayer();
            break;
            case "secondaryCharacter":  ConfrontPlayer();
            break;
            default:    Debug.Log("TIPO DE ENEMIGO NO ENCONTRADO");
            break;
        }
    }

    public void RotateAroundPlayer(){

        LookPlayer();
        transform.RotateAround(playerTransform.position, Vector3.up, 10f * Time.deltaTime);
    }

    public void ChasePlayer(){

        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);

        if (direction.magnitude >= 3f)
            transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void LookPlayer(){

        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private void ConfrontPlayer(){

        gameObject.transform.LookAt(playerTransform);
    }

}
