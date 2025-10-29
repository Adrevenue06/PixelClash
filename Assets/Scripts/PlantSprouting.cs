using UnityEngine;
using TMPro;

public class PlantSprouting : MonoBehaviour
{
    public ParticleSystem water;
    public ParticleSystem sproutEffect;
    public FollowMouse followMouse;
    public Animator anim;
    public TextMeshProUGUI treeText;
    public float treeCount;
    public coinmanager cm;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        {
            if(other.gameObject.CompareTag("Coin"))
            {
                cm.coinCount++;
            }
        }
        if (other.CompareTag("Water"))
        {
            if (followMouse.Starttime + 5f < Time.time)
            {
                anim.SetBool("isSprouting", true);
                sproutEffect.Play();
            }
            else if (followMouse.Starttime + 10f < Time.time)
            {
                anim.SetBool("isGrowing", true);
                sproutEffect.Play();
            }
            else if (followMouse.Starttime + 20f < Time.time)
            {
                anim.SetBool("isMature", true);
                sproutEffect.Play();
                Destroy(gameObject, 3f);
                treeCount += 1;
                treeText.text = "Trees Planted: " + treeCount.ToString();
            }
        }
    }
}
