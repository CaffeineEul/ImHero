using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : MonoBehaviour
{
    public enum Class
    {
        Dealer,
        Tanker,
        Supporter
    }

    [SerializeField] protected string className;
    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    [SerializeField] protected int range;
    [SerializeField] protected int h;
    [SerializeField] protected int v;
    [SerializeField] protected bool canAttack = false;
    public LayerMask _LayerMask;

    public Class me;

    protected TurnController turnController;

    public void Awake()
    {
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();

        switch (me)
        {
            case Class.Dealer:
                className = "Dealer";
                hp = 4;
                damage = 3;
                range = 2;
                break;
            case Class.Tanker:
                className = "Tanker";
                hp = 6;
                damage = 2;
                range = 1;
                break;
            case Class.Supporter:
                className = "Supporter";
                hp = 2;
                damage = 0;
                range = 3;
                break;
        }
    }

    public int GetHp()
    {
        return hp;
    }
    public int GetDamage()
    {
        return damage;
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
    /// 서포터가 힐 할때 호출되는 함수입니다
    /// </summary>
    /// <param name="target"></param>
    /// <param name="heal"></param>
    public virtual void Heal(Operator target, int heal)
    {
        turnController.MinusMb();
        target.hp += damage;
        if (hp >= 6) hp = 6;
    }

    /// <summary>
    /// 오퍼레이터가 체력이 다해 죽었는지 반환 하는 함수입니다
    /// </summary>
    /// <returns></returns>
    protected bool IsDead()
    {
        return hp <= 0;
    }

    /// <summary>
    /// 사거리 내 공격 가능한 대상이 있는지 리턴합니다
    /// </summary>
    /// <returns></returns>
    protected bool CanAttack()
    {
        return canAttack;
    }

    protected void SetCanAttack()
    {
        canAttack = !canAttack;
    }

    public string GetName()
    {
        return className;
    }
}
