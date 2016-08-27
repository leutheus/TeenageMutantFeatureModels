
# TeenageMutantFeatureModels</h1>
============================
## A genetic generator for realistic attributed variability models</h2>


<p align="center">
<img alt="overview" src="https://github.com/leutheus/TeenageMutantFeatureModels/blob/master/docs/overview.png" width="546">
</p>
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
![varmod](https://github.com/leutheus/TeenageMutantFeatureModels/blob/master/docs/varmod.png)

#### Feature Distribution
1. Chose from the predefined non-functional properties binarysize, mainmemory, performance or a random function
2. Select one system as the target feature distribution
3. Bootstrap the data sample to the targeted variability model size
 * It is possible to repeat the bootstrap process to receive another random draw of the density estimate
4. Select one distribution as target feature distribution
![feat](https://github.com/leutheus/TeenageMutantFeatureModels/blob/master/docs/feat.png)

#### Interaction Distribution
1. Same as feature distribution just for the interactions

#### Variant Distribution
TODO

#### Variant Sampling
TODO

#### Genetic Settings
TODO

#### Evolution
TODO

#### Solutions
TODO

