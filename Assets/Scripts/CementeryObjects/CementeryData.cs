using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CementeryData : MonoBehaviour {

    [SerializeField][Range(20, 200)] private int damagePoints = 20;
    public int DamagePoints { get { return damagePoints; } }

}
