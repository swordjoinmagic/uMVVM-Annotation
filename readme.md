# uMVVM #

这里是对 @木宛城主 大大的Unity MVVM UI框架uMVVM的我的一些注解~~

方便更好的理解一下这个框架的实现步骤~

## 简单概括 ##
下面是对uMVVM框架的运行机制简单概括

### View-视图类的运行过程总结 ###
View类的运行过程如下所示:
<center>
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
</center>