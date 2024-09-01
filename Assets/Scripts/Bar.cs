using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private Image image;
    private int index;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapBar()
    {

        index++;

        image.sprite = sprites[index];
    }

    public void ResetBar()
    {
        index = 0;
        image.sprite = sprites[index];
    }
}
