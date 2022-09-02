using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] GameObject foodManager;

    /*[SerializeField] ZombieManager zombieManager;

    [SerializeField] ObjectsManager objectsManager; */

    private PlayerData playerData;
    
    // Start is called before the first frame update
    void Start(){

        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update(){
        
        //MANEJAR CASOS DE GAME OVER
        if (GameManager.GameOver == false){
            if (playerData.HP <= 0){
                Debug.Log("GAME OVER -- SIN VIDA");
                GameManager.GameOver = true;
            }else if (GameManager.Timer <= 0f){
                Debug.Log("GAME OVER -- SIN TIEMPO");
                GameManager.GameOver = true;
            }else if (GameManager.Timer <= 20f && GameManager.Score <= 50){
                Debug.Log("GAME OVER -- POCO PUNTAJE");
                GameManager.GameOver = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "cementeryObject"){
            //DAMAGE
            playerData.Damage(other.gameObject.GetComponent<CementeryData>().DamagePoints);
            Debug.Log("VIDA LUEGO DEL DAÑO: " + playerData.HP);
        }

    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Food"){
            FoodManager component = foodManager.GetComponent<FoodManager>();
            component.GrabFood(other.gameObject);

            //esperar un rato antes de comer
            //component.EatsFood(other.gameObject);

            component.FoodList.Add(other.gameObject);   //agrego la comida a la lista
            
            //HEAL
            FoodData foodData = other.gameObject.GetComponent<FoodData>();
            playerData.Healing(foodData.HealPoints);
            Debug.Log("VIDA LUEGO DE COMER: " + playerData.HP);

            GameManager.Score += 30;
            Debug.Log("SCORE: " + GameManager.Score);

            if (GameManager.Timer <= 20f && GameManager.Score <= 50){
                component.FoodList.Clear();
                GameManager.GameOver = true;
            }
        }
    }
}
