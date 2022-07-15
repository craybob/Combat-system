using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackDetection : MonoBehaviour
{
    public int damage;
    BaseCharacter CharacterScr;

    void Start()
    {
        CharacterScr = GetComponentInParent<BaseCharacter>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy") //&& CharacterScr.mayAttack == true)
        {
            if (CharacterScr.mayAttack)
            {
                collision.gameObject.GetComponent<BaseEnemyScr>().TakeDamage(damage);
                Debug.Log("ouch");
                CharacterScr.mayAttack = false;
            }
        }
    }
}
