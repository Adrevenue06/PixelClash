using UnityEngine;

public class PlantSprouting : MonoBehaviour
{
    public ParticleSystem water;
    public ParticleSystem sproutEffect;
    public FollowMouse followMouse;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            if (followMouse.Starttime + 5f < Time.time)
            {
                anim.SetBool("isSprouting", true);
                sproutEffect.Play();
            }
            else if (followMouse.Starttime + 15f < Time.time)
            {
                anim.SetBool("isGrowing", true);
                sproutEffect.Play();
            }
        }
    }
}
