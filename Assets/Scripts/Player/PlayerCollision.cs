using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] GameObject foodManager;

    [SerializeField] ZombieManager zombieManager;

    private PlayerData playerData;
    
    private int countFood = 0;
    // Start is called before the first frame update
    void Start(){

        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update(){
        
        //MANEJAR CASOS DE GAME OVER
        if (GameManager.GameOver == false){

            VerifyCounter();    //desaparecen las comidas

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

        if (other.gameObject.tag == "enemy"){

            if (zombieManager.ZombieDirectory.ContainsKey(other.gameObject.name) == false){

                zombieManager.ZombieDirectory.Add(other.gameObject.name,other.gameObject);
                Debug.Log("ZOMBIE AGREGADO: " + zombieManager.ZombieDirectory[other.gameObject.name]);
                
                playerData.Damage(500);
                Debug.Log("VIDA LUEGO DEL DAÑO: " + playerData.HP);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Food"){
            countFood++;

            FoodManager component = foodManager.GetComponent<FoodManager>();
            component.EatsFood(other.gameObject);

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

    private void VerifyCounter(){

        if (countFood == 5){
            FoodManager component = foodManager.GetComponent<FoodManager>();
            component.KillFood();
            countFood = 0;
        }
    }
}
