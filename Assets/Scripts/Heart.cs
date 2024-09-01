using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapHeart(int index)
    {
        img.sprite = sprite[index];
    }
}
