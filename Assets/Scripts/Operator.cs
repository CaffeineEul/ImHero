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
    public LayerMask _LayerMask;

    public Class me;

    protected TurnController turnController;

    public void Awake()
    {
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();

        switch (me)
        {
            case Class.Dealer:
                name = "Dealer";
                hp = 4;
                damage = 3;
                range = 2;
                break;
            case Class.Tanker:
                name = "Tanker";
                hp = 6;
                damage = 2;
                range = 1;
                break;
            case Class.Supporter:
                name = "Supporter";
                hp = 2;
                damage = 0;
                range = 3;
                break;
        }
    }

    /// <summary>
    /// ������ �� ȣ��Ǵ� �Լ��Դϴ�
    /// </summary>
    /// <param name="target">������ ���</param>
    /// <param name="damage">���� ���ݷ�</param>
    public virtual void Attack(Operator target, int damage)
    {
        turnController.MinusMb();
        target.hp -= damage;
        return;
    }

    /// <summary>
    /// ���۷����Ͱ� ü���� ���� �׾����� ��ȯ �ϴ� �Լ��Դϴ�
    /// </summary>
    /// <returns></returns>
    protected bool IsDead()
    {
        return hp < 0;
    }

    /// <summary>
    /// ��Ÿ� �� ���� ������ ����� �ִ��� �����մϴ�
    /// </summary>
    /// <returns></returns>
    protected bool CanAttack()
    {
        Debug.DrawRay(transform.position, new Vector3(-1, -1, 0) * range, new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -1, 0) * 0.9f, _LayerMask);

        if (hit.transform.gameObject.tag == "Character")
        {
            return true;
        }

        return false;
    }

    public string GetName()
    {
        return className;
    }
}
