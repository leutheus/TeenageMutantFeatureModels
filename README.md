# TeenageMutantFeatureModels

A genetic generator for attributed variability models written in C#.
![Overview](https://github.com/leutheus/TeenageMutantFeatureModels/blob/master/docs/overview.png)

With the help of:
* [SPLConqueror] (https://github.com/nsiegmun/SPLConqueror)
* [JMetal.Net] (http://jmetalnet.sourceforge.net/)
* [Accord.Net] (http://accord-framework.net/)

## Quickstart Guide

This chapter describes the required steps to get started.  

### 1. Requirements
* Windows only
* .NET Framework 4.5 or higher
* TODO
* 
### 2. Compilation

* Clone this Repo
* Install [R](https://www.r-project.org/)
 * Install the R Packages
  * ks
  * ggplot2
  * scatterplot3d
  * scales
  * gridExtra
* Restore the Nuget Packages
* Compile
 * TODO
 * TODO

### 3. Get Started
#### Variability Model Settings and Fitness Selection
1. Load a Variability Model  (e.g. from [BeTTy](http://www.isa.us.es/betty/betty-online), [SPLOT](http://www.splot-research.org/) )
2. Select the desired amount of interactions and the order of interactions
 * Order of interactions must sum up to 100%
3. Declare which types should be optimized (fitness calculation)
 * Features
 * Interactions
 * Variants
 * Any combination of the above (Multi-objective)
#### Feature Distribution
1. Chose from the predefined non-functional properties binarysize, mainmemory, performance or a random function
2. Select one system as the target feature distribution
3. Bootstrap the data sample to the targeted variability model size
4. 


