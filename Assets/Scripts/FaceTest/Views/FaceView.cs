using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using uMVVM;
using UnityEngine.EventSystems;

class FaceView : UnityGuiView<FaceViewModel>{
    //===================================
    // 以下是该View管理的ugui控件
    //==================================
    public BadgeView badgeView;     // subView
    public Text levelText;      //等级
    public Image faceImage;     // 头像(略过)
    public Text nameText;       // 姓名

    // 事件监听器
    public EventTrigger eventTrigger;

    private void Awake() {
        BindingContext = new FaceViewModel();

        // 显示该视图
        Reveal();
    }

    protected override void OnInitialize() {
        base.OnInitialize();
        // 初始化Binder属性绑定器
        binder.Add<Badge>("Badge",OnBadePropertyValueChanged);
        binder.Add<string>("Name",OnNamePropertyValueChanged);
        binder.Add<int>("Level",OnLevelPropertyValueChanged);

        // 监听事件
        var pointClickEntry = new EventTrigger.Entry();
        pointClickEntry.eventID = EventTriggerType.PointerClick;
        pointClickEntry.callback.AddListener(eventData => {
            print("单击了头像");
            OnClick();
        });
        eventTrigger.triggers.Add(pointClickEntry);
    }

    // 处理头像点击事件,这里交给ViewModel去处理
    private void OnClick() {
        if (BindingContext.OnClick != null) {
            BindingContext.OnClick();
        }
    }

    /// <summary>
    /// 当Badge的Model(不是ViewModel)改变的时候,
    /// 改变BadgeView的ViewModel的值
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private void OnBadePropertyValueChanged(Badge oldValue,Badge newValue) {

        print("子视图BadgeView的Model改变了,触发方法");

        if (badgeView.BindingContext == null) {
            badgeView.BindingContext = new BadgeViewModel();
        }
        badgeView.BindingContext.Initialization(newValue);
    }

    private void OnLevelPropertyValueChanged(int oldValue,int newValue) {
        levelText.text = newValue.ToString("00");
    }

    private void OnNamePropertyValueChanged(string oldValue,string newValue) {
        nameText.text = newValue;
    }
}

