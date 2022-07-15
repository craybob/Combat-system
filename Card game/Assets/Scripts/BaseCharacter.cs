using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour, IControllable
{
    InputController inputScr;
    CharacterController control;
    [HideInInspector] public Animator anim;

    public float time2Attack;
    [HideInInspector] public float currentTime;

    [HideInInspector] public bool mayAttack = false;
    [SerializeField] int comboStep = 0;

    [SerializeField] float comboResetTime;
    float currentComboTime;

    void Start()
    {
        anim = GetComponent<Animator>();
        inputScr = GetComponent<InputController>();
        control = GetComponent<CharacterController>();
    }

    public void Attack()
    {

        anim.SetInteger("ComboStep", comboStep);
        if (Input.GetKeyDown(KeyCode.Mouse0) && !mayAttack)
        {
            comboStep++;
            StartCoroutine("ComboStart");
            //currentTime = time2Attack;
            currentComboTime = comboResetTime;

            mayAttack = true;
        }

        if (comboStep >= 4)
        {
            ResetCombo();
        }

        if (currentComboTime < 0)
        {
            ResetCombo();
        }
    }

    IEnumerator ComboStart()
    {
        anim.Play("Combo" + comboStep);
        Debug.Log("start");
        yield return new WaitForSeconds(time2Attack);
        Debug.Log("end");
        mayAttack = false;
    }

    void ResetCombo()
    {
        comboStep = 0;
    }

    public void Move()
    {

        control.Move(inputScr.moveDir * Time.deltaTime);
        anim.SetFloat("Speed",Mathf.Abs(inputScr.moveDir.z) + Mathf.Abs(inputScr.moveDir.x));
    }
}
