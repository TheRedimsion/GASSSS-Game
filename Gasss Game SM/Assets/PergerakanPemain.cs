using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergerakanPemain : MonoBehaviour
{
    private float mendatar;
    private float kecepatan = 8f;
    private float kuatLompatan = 16f;
    private bool hadapKanan = true;

    [SerializeField] private Rigidbody2D ribo;
    [SerializeField] private Transform cekDasar;
    [SerializeField] private LayerMask lapisanDasar;

    // Update is called once per frame
    void Update()
    {
        mendatar = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && DiDasar())
        {
            ribo.velocity = new Vector2(ribo.velocity.x, kuatLompatan);
        }
        // untuk menambah kekuatan lompat jika ditekan lebih lama
        if(Input.GetButtonUp("Lompat") && ribo.velocity.y > 0f)
        {
            ribo.velocity = new Vector2(ribo.velocity.x, ribo.velocity.y * 0.5f);
        }

        gerak();
    }

    private void FixedUpdate()
    {
        ribo.velocity = new Vector2(mendatar * kecepatan, ribo.velocity.y);
    }

    private bool DiDasar()
    {
        return Physics2D.OverlapCircle(cekDasar.position, 0.2f, lapisanDasar);
    }

    private void gerak()
    {
        if(hadapKanan && mendatar < 0f || hadapKanan && mendatar > 0f)
        {
            hadapKanan = !hadapKanan;
            Vector3 skalaLokal = transform.localScale;
            skalaLokal.x = skalaLokal.x * -1f;
            transform.localScale = skalaLokal;
        }
    }
}
