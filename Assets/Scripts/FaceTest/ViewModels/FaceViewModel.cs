using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMLerning;
using UnityEngine;

class FaceViewModel : ViewModelBase{
    public readonly BindableProperty<string> Name = new BindableProperty<string>();
    public readonly BindableProperty<int> Level = new BindableProperty<int>();
    public readonly BindableProperty<string> Face = new BindableProperty<string>();
    public readonly BindableProperty<Badge> Badge = new BindableProperty<Badge>();

    public override void OnStartReveal() {
        base.OnStartReveal();
        Debug.Log("正在初始化FaceViewModel");
        Initialization();
        Debug.Log("初始化FaceViewModel完成");
    }

    public void Initialization() {
        Name.Value = "比尔";
        Level.Value = 9;
        //Face.Value = "13213";
        Debug.Log("正在初始化Badge");
        Badge.Value = new Badge() { Icon="asdasd",ElementColor="Red" };
        Debug.Log("初始化Badge结束");
    }
}
