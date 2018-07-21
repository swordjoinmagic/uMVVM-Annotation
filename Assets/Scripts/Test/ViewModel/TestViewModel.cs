using System;
using System.Collections.Generic;
using MVVMLerning;

class TestViewModel : ViewModelBase{
    public BindableProperty<string> Text = new BindableProperty<string>();
}
