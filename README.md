# **Space Shooter**
_Space Shooter_ is a small 2D game made in Unity 2022-3-10f1 using C# and ECS. The goal of this project was to create a shooter with huge amounts of enemies using Unity standard GameObject / MonoBehaviour approach and later install ECS and convert the GameObject into *entities* and monitor
perfomance improvements.

I have firstly created the whole game without any ECS package. After giving it a fair shot I downloaded the ECS packages and started creating the same game with DOTS. Every aspect of the game is made using ECS which i am really proud of and the difference in perfomnance is immense.

| Scene  |Enemies | FPS|
| ------ | ------ |------|
| GameObjects / Monobehaviour |  4000  | >30 | 
| Entity / ECS | 100000 | >30 | 

ECS enabled me to have **2400%** increase in enemies with same FPS.

I have tried to utilized most of the features that ECS has to offer which to squeeze out the most perfomance out of the PC. 
 
### Efficient use of computer hardware

- **Multi-threading**

  New modern CPUs have many cores and a lot of them even have 2 threads per cpu core just as mine. By using the "Unity Job system" i schedulled jobs which allows CPU to ran tasks in parallel, utilizing the multi-threading 
- **Burst Compiler**

  Burst is a compiler which comes as a part of the ECS package which translates C# code to vastly optimized native code, as a result greatly improving improvement of perfomance critical parts of the game. Burst compiler has it's limitations too. As it is now burst can only convert
  functions or jobs with unmanaged/primitive types in order to work.

- **Minimal overhead**

  Entities are very barebones object types, conver§ting the objects makes a huge boost in perfomance due to eliminated overhead using GameObjects and MonoBehaviour.

- **Reduced GC**

  DOTS/ECS package largely reduces the cost for garbage collection. The documenatation states that is uses memory pooling system to minimize the spike caused by memory allocation.


 ## Data-oriented Design

 - **Components**

   Entities start out as very barebone objects. In order to add functionality to them you create your own component via code which you later add during the conversion from GameObject. The component data is stored very close together in the memory which makes it very fast to access and       manipulate

 - **Systems**

   Systems in ECS are responsible to do tasks on the supplied data from the *Entity components*. Systems utilize the power of modern CPUs by sending operations to other threads and doing so in parallel make for a huge perfomance gain.

 - **Cache Efficiency**

   ECS tries to store data of the same type close in the Cache memory to reduce the lookup time when doing Querys<> for example. The systems exhibits a pattern of chunks of data that were repeatedly accessed. 
 
 ## Profiler debugging and Optimization

 When creating the game i have used the Profiler to point me in the right direction to change the code. Instatiation hundrends of objects a the same time was costly so I decided to create a pooling system to minimize the spikes of the application.


## Usage
Use the following controls to play the game:
| Controls  | Explanation |
| ------ | ------ |
| W and S |  Moving Forward / Backwards  | 
| A and D |  Rotating left and right | 
| Space | Shoot | 


## Installation
To install and play Endless Runner, simply download the latest release from the "Release" section on the GitHub repository page and launch the executable.
