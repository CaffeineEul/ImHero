using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    [SerializeField] protected string name;
    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    [SerializeField] protected int moveDistance;
    [SerializeField] protected int attackRange;
    [SerializeField] protected int h;
    [SerializeField] protected int v;

    public enum Class
    {
        Dealer,
        Tanker,
        Supporter
    }

    protected TurnController turnController;

    public void Start()
    {
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
    }

    /// <summary>
    /// 공격할 때 호출되는 함수입니다
    /// </summary>
    /// <param name="target">공격할 대상</param>
    /// <param name="damage">가한 공격력</param>
    public virtual void Attack(Operator target, int damage)
    {
        turnController.MinusMb();
        target.hp -= damage;
        return;
    }

    /// <summary>
    /// 오퍼레이터가 체력이 다해 죽었는지 반환 하는 함수입니다
    /// </summary>
    /// <returns></returns>
    protected bool IsDead()
    {
        return hp < 0;
    }

    /// <summary>
    /// 사거리 내 공격 가능한 대상이 있는지 리턴합니다
    /// </summary>
    /// <returns></returns>
    protected bool CanAttack()
    {
        Debug.DrawRay(transform.position, new Vector3(-1, -1, 0) * attackRange, new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -1, 0) * 0.9f);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }

        return false;
    }
}
