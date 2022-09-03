using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {
    [SerializeField] [Range(0.5f,15f)] float speed = 3f;

    [SerializeField] Transform playerTransform;
    
    [SerializeField] ZombieManager manager;

    private void Update() {

        if (manager.ZombieDirectory.ContainsKey(gameObject.name)){
            /*if (Input.GetKey(KeyCode.Alpha1)) zombieController(manager.ZombieDirectory["zombieA"]);
            if (Input.GetKey(KeyCode.Alpha2)) zombieController(manager.ZombieDirectory["zombieC"]);
            if (Input.GetKey(KeyCode.Alpha3)) zombieController(manager.ZombieDirectory["secondaryCharacter"]);*/

            if (Input.GetKey(KeyCode.Alpha1) && gameObject.name == "zombieA") 
                zombieController(manager.ZombieDirectory["zombieA"]);
        }

    }

    public void zombieController(GameObject zombie){

        switch (zombie.name){
            case "zombieA": ChasePlayer();
            break;
            case "zombieC": RotateAroundPlayer();
            break;
            case "secondaryCharacter":  //ChasePlayer();
                                        ConfrontPlayer();
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

        if (direction.magnitude >= 2f)
            transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void LookPlayer(){

        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    public void ConfrontPlayer(){

        transform.Rotate(new Vector3(0f,180f,0f));
    }
}
