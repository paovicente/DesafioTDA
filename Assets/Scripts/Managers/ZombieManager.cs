using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {

    private Dictionary<string, GameObject> zombieDirectory;
    public Dictionary<string, GameObject> ZombieDirectory { get => zombieDirectory; set => zombieDirectory = value; }

    // Start is called before the first frame update
    void Start(){

        zombieDirectory = new Dictionary<string, GameObject>();
    }

}
