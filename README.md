# **Space Shooter**
_Space Shooter_ is a small 2D game made in Unity 2022-3-10f1 using C# and ECS. The goal of this project was to create a shooter with huge amounts of enemies using Unity standard GameObject / MonoBehaviour approach and later install ECS and convert the GameObject into *entities* and monitor
perfomance improvements.

### Efficient use of computer hardware

- **Multi-threading**

  New modern CPUs have many cores and a lot of them even have 2 threads per cpu core just as mine. By using the "Unity Job system" i schedulled jobs which allows CPU to ran tasks in parallel, utilizing the multi-threading 
- **Burst Compiler**

  Burst is a compiler which comes as a part of the ECS package which translates C# code to vastly optimized native code, as a result greatly improving improvement of perfomance critical parts of the game. Burst compiler has it's limitations too. As it is now burst can only convert
  functions or jobs with unmanaged/primitive types in order to work.

- **Minimal overhead**

  Entities are very barebones object types, conver§ting the objects makes a huge boost in perfomance due to eliminated overhead using GameObjects and MonoBehaviour.

- **Reduced GC**

  
  



## Data-oriented Design
  Endless Runner was designed using an object-oriented approach, which helped to make the code more modular and reusable. Each game mechanic is implemented as a separate class, with clear interfaces and responsibilities. This approach ensures that each class has only one responsibility and minimizes the risk of code duplication and coupling. Additionally, data is sealed off from other classes to prevent unintended modification.
 
  The game loop functionality is sealed off in the custom GameMode class (Game Manager), which manages the spawning of platforms, obstacles, and power-ups, as well as the increasing difficulty. This design decision makes it easy to iterate on the game in the future, as it centralizes the game logic in one place and allows for easy modification and extension.

 Overall, the object-oriented design of Endless Runner helps to keep the code organized, maintainable, and scalable.

 ## Profiler debugging and Optimization


## Usage
Use the following controls to play the game:
| Controls  | Explanation |
| ------ | ------ |
| W and S |  Moving Forward / Backwards  | 
| A and D |  Rotating left and right | 
| Space | Shoot | 


## Installation
To install and play Endless Runner, simply download the latest release from the "Release" section on the GitHub repository page and launch the executable.
