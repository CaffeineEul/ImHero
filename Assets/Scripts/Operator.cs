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
        Debug.DrawRay(transform.position, new Vector3(-1, -1, 0) * attackRange, new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -1, 0) * 0.9f);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }

        return false;
    }
}
