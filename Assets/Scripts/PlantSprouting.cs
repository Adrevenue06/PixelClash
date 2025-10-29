using UnityEngine;
using TMPro;

public class PlantSprouting : MonoBehaviour
{
    public ParticleSystem sproutEffect;
    public FollowMouse followMouse;
    public Animator anim;
    public TextMeshProUGUI treeText;
    public float treeCount;
    public Collider2D plantCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (followMouse.Starttime + 2f < Time.time)
        {
            anim.SetBool("isSprouting", true);
            //sproutEffect.Play();
        }
        else if (followMouse.Starttime + 4f > Time.time)
        {
            anim.SetBool("isSprouting", false);
        }
        if (followMouse.Starttime + 4f < Time.time)
        {
            anim.SetBool("isGrowing", true);
            //sproutEffect.Play();
        }
        else if (followMouse.Starttime + 6f > Time.time)
        {
            anim.SetBool("isGrowing", false);
        }
        if (followMouse.Starttime + 6f < Time.time)
        {
            anim.SetBool("isMature", true);
            //sproutEffect.Play();
            Destroy(gameObject, 3f);
            treeCount += 1;
            //treeText.text = "Trees Planted: " + treeCount.ToString();
        }
        

        Debug.Log(followMouse.Starttime);
            Debug.Log(Time.time);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("water"))
        {
            followMouse.Starttime = Time.time;
        }
        
    }
}


