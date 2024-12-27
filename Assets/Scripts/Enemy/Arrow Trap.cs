using System.Collections;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject arrows;
    private float cooldownTimer;

    private IEnumerator Attack()
    {
        cooldownTimer = 0;
        for (int i = 0; i < 5; i++)
        {
            GameObject Arrows = Instantiate(arrows, firePoint.position,  Quaternion.identity);
            Arrows.SetActive(true);
            Arrows.transform.eulerAngles = new Vector3(0, 0, -90);
            yield return new WaitForSeconds(0.5f);

        }
        yield return null;
      
       // arrows[FindArrow()].transform.position = firePoint.position;
       // arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    //private int FindArrow()
    //{
    //    for (int i = 0; i < arrows.Length; i++)
    //    {
    //        if (!arrows[i].activeInHierarchy) // bong do ko hoat dong trong hierachy thi lay no ra
    //            return i;

    //    }return 0;// neu ko chi su dung qua dau tien
    //}
    private void Update()
    {
        cooldownTimer += Time.deltaTime; // tang moi khung hinh
        if(cooldownTimer >= attackCooldown)
        {
            StartCoroutine(Attack());
            //Attack();
        }
    }
}
