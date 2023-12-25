using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private Animator anim;

    private float delay = 2f;

    private bool canTouch;

    private int index;

    public GameObject vfxScale;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        canTouch = true;

        index = 0;
    }

    private void Update()
    {
        if (!canTouch)
        {
            delay -= Time.deltaTime;
        }

        if (delay <= 0)
        {
            delay = 2f;
            canTouch = true;
        }
    }

    private void OnMouseDown()
    {
        if (!canTouch) return;

        canTouch = false;

        index += 1;
        anim.SetInteger("Scale", index);

        if (index == 2)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
        }
    }

    public void PlayVfx()
    {
        GameObject vfx = Instantiate(vfxScale, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
    }
}
