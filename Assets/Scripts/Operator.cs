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
    [SerializeField] protected bool chkEnemy;
    [SerializeField] protected ParticleSystem attackParticle;
    [SerializeField] protected ParticleSystem healedParticle;
    [SerializeField] protected ParticleSystem moveParticle;
    public LayerMask _LayerMask;

    public Class me;

    protected SoundController soundController;
    protected TurnController turnController;

    public void Awake()
    {
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>();

        switch (me)
        {
            case Class.Dealer:
                className = "Dealer";
                hp = 3;
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
                hp = 4;
                damage = 1;
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
    /// ������ �� ȣ��Ǵ� �Լ��Դϴ�
    /// </summary>
    /// <param name="target">������ ���</param>
    /// <param name="damage">���� ���ݷ�</param>
    public virtual void Attack(Operator target, int damage)
    {
        // SFX
        soundController.AttackSound();
        turnController.MinusMb();
        Instantiate(attackParticle, target.transform.position, Quaternion.identity);
        target.hp -= damage;
        return;
    }

    /// <summary>
    /// �����Ͱ� �� �Ҷ� ȣ��Ǵ� �Լ��Դϴ�
    /// </summary>
    /// <param name="target"></param>
    /// <param name="heal"></param>
    public virtual void Heal(Operator target, int heal)
    {
        if (target.hp >= 6) return;

        // SFX
        soundController.HealSound();
        turnController.MinusMb();
        ParticleSystem par = Instantiate(healedParticle, target.transform.position, Quaternion.identity);
        StartCoroutine(ParticleOff(par, 5f));
        target.hp += heal;
        target.hp = Mathf.Clamp(target.hp, 0, 6);
    }
    IEnumerator ParticleOff(ParticleSystem particle,float time)
    {
        yield return new WaitForSeconds(time);
        particle.Stop();
    }

    /// <summary>
    /// ���۷����Ͱ� ü���� ���� �׾����� ��ȯ �ϴ� �Լ��Դϴ�
    /// </summary>
    /// <returns></returns>
    protected bool IsDead()
    {
        // SFX -> CharacterInfo
        return hp <= 0;
    }

    /// <summary>
    /// ��Ÿ� �� ���� ������ ����� �ִ��� �����մϴ�
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
