using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Color filledBarColor = new Color(0.9f, 0.0f, 0.0f);
    public Gradient partiallyFilledBarGradient = new Gradient();
    //public Color partiallyFilledBarColor = new Color(0.6f, 0.0f, 0.0f);


    private GameObject healthSegment;

    private int _segment_count = 1;

    
    public int SegmentCount
    {
        get => _segment_count;
        set
        {
            _segment_count = Mathf.Max(value, 1);
            UpdateSegmentCount();
        }
    }

    private float _value = 0f;
    public float Value
    {
        get => _value;
        set
        {
            _value = Mathf.Clamp(value, 0.0f, _segment_count);
            UpdateVisuals();
        }
    }

    private void UpdateVisuals(){
        int partialSegmentIndex = Mathf.FloorToInt(Value);
        Slider slider;
        // Everything before me is 1
        for (int i = 0; i < partialSegmentIndex; i++){
            slider = transform.GetChild(i).GetComponent<Slider>();
            slider.value = 1.0f;
            foreach(Transform child in slider.transform) child.GetComponent<Image>().color = filledBarColor;
            
        }
        // Stop if everything is filled up
        if (partialSegmentIndex >= _segment_count) return;
        // I am fraction part of Value
        slider = transform.GetChild(partialSegmentIndex).GetComponent<Slider>();
        slider.value = Value - Mathf.Floor(Value);
        foreach(Transform child in slider.transform) child.GetComponent<Image>().color = partiallyFilledBarGradient.Evaluate(Value - Mathf.Floor(Value));
        //foreach(Transform child in slider.transform) child.GetComponent<Image>().color = partiallyFilledBarColor;
        // Everything after me is 0
        for (int i = partialSegmentIndex + 1; i < _segment_count; i++){
            transform.GetChild(i).GetComponent<Slider>().value = 0.0f;
        }
        

    }

    private void UpdateSegmentCount(){
        int childrenCount = transform.childCount;
        // Deleting unneeded segments
        for (int i = childrenCount -1; i >= _segment_count; i--){
            Destroy(transform.GetChild(i));
        }
        // Adding needed segments
        for (int i = childrenCount; i < _segment_count; i++){
            GameObject newSegment = Instantiate(healthSegment);
            newSegment.transform.SetParent(this.transform);
        }
        
    }

    void Awake()
    {
        Assert.AreEqual(transform.childCount, 1, "There supposed to be exactly 1 child of this object that is its segment");
        healthSegment = transform.GetChild(0).gameObject;
        Assert.IsNotNull(healthSegment, "Wasn't able to find segment");
    }

    void Start()
    {
        UpdateSegmentCount();
        UpdateVisuals();
    }
}
