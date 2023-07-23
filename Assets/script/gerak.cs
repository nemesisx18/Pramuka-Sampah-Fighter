using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gerak : MonoBehaviour
{
    [Header("Movement")]
    public float kecepatan;
    public bool balik;

    private Rigidbody2D rb;
    private float pindah;

    [Header("Jumping")]
    public float kekuatanLompat;
    public bool tanah;
    public LayerMask targetLayer;
    public Transform deteksiTanah;
    public float jangkauan;

    [Header("UI Components")]
    public TextMeshProUGUI infoNyawa;
    public TextMeshProUGUI infoKoin;

    [Header("Player Stats")]
    public int nyawa;
    public int koin;

    Vector2 mulai;
    public bool ulang;
    public bool tombolKiri;
    public bool tombolKanan;
    public bool tombolLompat;
    public bool lompat;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mulai = transform.position;
        UpdateUI();
    }

    void Update()
    {
        if (ulang)
        {
            transform.position = mulai;
            ulang = false;
        }

        if (nyawa <= 0)
        {
            Destroy(gameObject);
        }

        // Check if the player is on the ground
        tanah = Physics2D.OverlapCircle(deteksiTanah.position, jangkauan, targetLayer);

        // Set the "lari" boolean in the Animator based on the ground condition
        anim.SetBool("lari", Mathf.Abs(rb.velocity.x) > 0.1f && tanah);

        // Handle movement using Input
        pindah = Input.GetAxis("Horizontal");

        // Check if the left or right arrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow) || tombolKiri==true)
        {
            transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
            pindah = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || tombolKanan ==true)
        {
            pindah = 1;
        }

        // Apply movement velocity
        rb.velocity = new Vector2(pindah * kecepatan, rb.velocity.y);

        // Check if the jump button is pressed and the player is on the ground
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || tombolLompat==true) && tanah)
        {
            if (!lompat) // Only initiate jump if not already jumping
            {
                Lompat();
                lompat = true; // Set lompat to true during the jump
            }
        }

        // Additional logic to reset lompat when the player lands on the ground
        if (tanah)
        {
            lompat = false;
        }

        if (pindah > 0 && !balik)
        {
            BalikBadan();
        }
        else if (pindah < 0 && balik)
        {
            BalikBadan();
        }
    }

    public void Lompat()
    {
        rb.AddForce(new Vector2(0, kekuatanLompat), ForceMode2D.Impulse);
    }

    private void BalikBadan()
    {
        balik = !balik;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Functions for button input handling
    public void TekanKiri()
    {
        tombolKiri = true;
    }

    public void LepasKiri()
    {
        tombolKiri = false;
    }

    public void TekanKanan()
    {
        tombolKanan = true;
    }

    public void LepasKanan()
    {
        tombolKanan = false;
    }

    public void TekanLompat()
    {
        tombolLompat = true;
    }

    public void LepasLompat()
    {
        tombolLompat = false;
    }

    // Function to update the koin value
    public void UpdateKoin(int value)
    {
        koin += value;
        UpdateUI();
    }

    public void UpdateNyawa(int value)
    {
        nyawa += value;
        UpdateUI();
    }

    // Function to update the UI text for Nyawa and Koin
    void UpdateUI()
    {
        if (infoNyawa != null)
        {
            infoNyawa.text = "Nyawa: " + nyawa.ToString();
        }

        if (infoKoin != null)
        {
            infoKoin.text = "Koin: " + koin.ToString();
        }
    }
}
