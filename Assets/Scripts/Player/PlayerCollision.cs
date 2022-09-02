using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

   /* [SerializeField] FoodManager foodManager;

    [SerializeField] ZombieManager zombieManager;

    [SerializeField] ObjectsManager objectsManager; */

    private PlayerData playerData;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start(){

        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "cementeryObject"){
            //DAMAGE
            playerData.Damage(other.gameObject.GetComponent<CementeryData>().DamagePoints);
            Debug.Log("vida: " + playerData.HP);
        }
    }
}
