# uMVVM #

这里是对 @木宛城主 大大的Unity MVVM UI框架uMVVM的我的一些注解~~

方便更好的理解一下这个框架的实现步骤~

## 简单概括 ##
下面是对uMVVM框架的运行机制简单概括

### View-视图类的运行过程总结 ###
View类的运行过程如下所示:

	Awake  
	↓  
	Initialize(当该View第一次为其绑定的ViewModel赋值的时候,调用该方法),同时,调用ViewModel的Initiallize方法    
	↓  
	进行显示(Reveal) 或 进入Start  
	↓  
	进行显示的情况 : 此处进入 OnApear,OnReveal,OnRevealed状态中  
	进入Start的情况 : 此处进入Update,进行更新事宜,等待某一个事件使当前View进入Reveal状态  
	↓  
	Update,在Update状态中,等待某个事件使View进入显示(Reveal)状态或是隐藏(Hide)状态  
	↓  
	Destroy,在Destroy状态下,View调用OnDestroty方法,同时调用ViewModel的OnDestroy方法.




## 注解日志 ##
这里记录一下，一遍看uMVVM框架源码一边注释时我自己的一些体会~

### 7/24/2018 2:18:11 PM  ###
完成subView,subViewModel第一部分的注解，了解了subView是该框架复用的一种手段，当一个view考虑要在不同的场景下使用2次以上时，就要考虑将其变成subView，一个subView由View，Model，ViewModel组成，在包含一个subView的视图View类中，使用subView的Model来关联该subView，具体来说就是，将一个Model（类似JavaBean）变成可绑定属性放入主视图View的ViewModel中去，当subView的Model发生变化时，自动触发一个方法，在该方法中更新subView的ViewModel的属性，此时因为subView的ViewModel的属性发生改变，所以子视图自动发生了改变。