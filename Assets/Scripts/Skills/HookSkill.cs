using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSkill : Skill
{
    private SkillsCharacteristics _characteristics;
    private GameObject projectile;

    private bool cancelled;

    public HookSkill()
    {
        data = CombinationManager.Instance.GetSkillData("hook");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        projectile = _characteristics.hookPrefab;
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
       
        player.GetComponent<PlayerMana>().Mana -= data.cost;

        var coroutine = SkillCoroutine(player, direction);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
        
        
    }

    private IEnumerator SkillCoroutine(GameObject player, float angle)
    {
        cancelled = false;
        player.GetComponent<Animator>().ResetTrigger("EndSkill");
        player.GetComponent<Animator>().SetTrigger("Hook");
        yield return new WaitForSeconds(0.15f);
        var thing = Object.Instantiate(projectile, player.transform.position + new Vector3(0.3f, 1.0f, 0.0f), Quaternion.identity);
        thing.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        thing.GetComponent<Rigidbody2D>().velocity = AngleToVec2(angle) * _characteristics.hookSpeed;
        thing.GetComponent<DamageDealer>().damage = _characteristics.hookDamage;
        thing.GetComponent<Rigidbody2D>().rotation = angle - 90f;
        thing.GetComponent<LineObjectFollower>().obj = player.transform.Find("Center");
        Collider2D collider = null;
        thing.GetComponent<DamageDealer>().OnCollision.AddListener((Collider2D _collider) => collider = _collider);
        // Waiting for collision
        while(collider == null && cancelled == false){
            yield return new WaitForFixedUpdate();
        }
        if (collider != null){
            //If collision Found
            //Disable hook's movment
            thing.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            List<Collider2D> thingColliders = new List<Collider2D>();
            thing.GetComponent<Rigidbody2D>().GetAttachedColliders(thingColliders);
            foreach (Collider2D thingCollider in thingColliders){
                thingCollider.enabled = false;
            }
            // Flip lever | No longer used due to Lever Toucher Class
            // Lever lever = collider.GetComponent<Lever>();
            // if(lever != null){
            //     lever.Turn(Lever.Position.Left);
            // }
            // Pull object towards player
            PullableBody pullable = collider.GetComponent<PullableBody>();
            if(pullable != null){
                float time = 0.0f;
                Coroutine pullCoroutine = pullable.Pull(player.transform.Find("Center"), _characteristics.hookEnemyPullSpeed, 2.0f);
                while(collider!=null && (((Vector2)player.transform.position)-(Vector2)collider.transform.position).magnitude > 2.0f){
                    thing.GetComponent<Rigidbody2D>().position = collider.transform.position;
                    time += Time.fixedDeltaTime;
                    if (cancelled || time >= _characteristics.hookTimeLimit){
                        pullable.StopCoroutine(pullCoroutine);
                        break;
                    }
                    yield return new WaitForFixedUpdate();
                }
            }
            // Pull player towards ground
            if(collider!=null && collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
                float time = 0.0f;
                Vector2 delta = ((Vector2)player.transform.position)-(Vector2)thing.transform.position;
                while(delta.magnitude > 1.0f){
                    player.GetComponent<Rigidbody2D>().velocity = - delta.normalized * _characteristics.hookPlayerTravelSpeed;
                    time += Time.fixedDeltaTime;
                    if (cancelled || time >= _characteristics.hookTimeLimit){
                        break;
                    }
                    yield return new WaitForFixedUpdate();
                    delta = ((Vector2)player.transform.position)-(Vector2)thing.transform.position;
                }
            }
        }
        Object.Destroy(thing);        
    }

    public override void Cancel(){
        cancelled = true;
    }
    
}
