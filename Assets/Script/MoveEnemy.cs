using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 0.2f;
    [SerializeField]
    private float gravity = 20f;
    [SerializeField]
    private int enemyHp = 1;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;
    private GameObject player = null;
    private Coroutine removeHpCoroutine = null;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = Vector3.zero;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (controller.isGrounded && player)
        { 
            if (dist > 2f && enemyHp > 0 && GetComponent<Animator>().GetBool("isAttack") == false)
            {
                transform.LookAt(player.transform);
                moveDirection = player.transform.position - transform.position;         
                moveDirection *= movementSpeed;
            }
            if (dist < 2f && GetComponent<Animator>().GetBool("isRun") == false)
            {
                GetComponent<Animator>().SetBool("isAttack", true);
                GetComponent<Animator>().SetBool("isRun", false);
                if (removeHpCoroutine == null)
                    removeHpCoroutine = StartCoroutine(RemoveHpAfterTime());
            }
            else
            {
                GetComponent<Animator>().SetBool("isAttack", false);
                GetComponent<Animator>().SetBool("isRun", false);
            }

            
            if (moveDirection != Vector3.zero)
                GetComponent<Animator>().SetBool("isRun", true);
            else
                GetComponent<Animator>().SetBool("isRun", false);

        }

        dist = Vector3.Distance(player.transform.position, transform.position);
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    IEnumerator RemoveHpAfterTime()
    {
        yield return new WaitForSeconds(1.5f);

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 2f && GetComponent<Animator>().GetBool("isAttack"))
        {
            GetComponent<Animator>().SetBool("isAttack", false);
            PlayerHp.UpdateHp();
        }
        yield return new WaitForSeconds(4f);
        removeHpCoroutine = null;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            enemyHp--;
            if (enemyHp <= 0)
            {
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<CharacterController>().enabled = false;
                GetComponent<Animator>().SetBool("isDeath", true);
                Destroy(gameObject, 4f);
                Hud.scoring += 200;
            }
        }
    }
}
