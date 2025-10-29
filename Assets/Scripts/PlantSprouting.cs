using UnityEngine;
using TMPro;

public class PlantSprouting : MonoBehaviour
{
    public ParticleSystem sproutEffect;
    public FollowMouse followMouse;
    public TextMeshProUGUI treeText;
    public float treeCount;
    float Timer;
    public Collider2D plantCollider;
    public GameObject Frame1;
    public GameObject Frame2;
    public GameObject Frame3;
    public GameObject Frame4;
    public GameObject Frame5;
    public GameObject Frame6;
    public bool canTouching;

    void Start()
    {
    }

    void Update()
    {
        if (canTouching && followMouse.isWatering)
        {
            Timer += Time.deltaTime;
            if (Timer >= 3f)
            {
                Frame1.SetActive(false);                
                Frame2.SetActive(true);

            }
            if (Timer >= 7f)
            {
                Frame2.SetActive(false);
                Frame3.SetActive(true);
                

            }
            if (Timer >= 10f)
            {
                //sproutEffect.Play();
                Frame3.SetActive(false);
                Frame4.SetActive(true);
                

            }
            if (Timer >= 13f)
            {
                Frame4.SetActive(false);
                Frame5.SetActive(true);
                
            }
            if (Timer >= 16f)
            {
                //sproutEffect.Play();
                Frame5.SetActive(false);
                Frame6.SetActive(true);
                Destroy(gameObject, 3f);
                //treeCount += 1;
                //treeText.text = "Trees Planted: " + treeCount.ToString();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("watercan"))
        {
            canTouching = true;
            Debug.Log("can touch");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("watercan"))
        {
            canTouching = false;
        }
    }
}


