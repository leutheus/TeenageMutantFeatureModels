﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using SPLConqueror_Core;

namespace MachineLearning.Solver
{
    public interface IVariantGenerator
    {
        /// <summary>
        /// Generates all valid binary combinations of all binary configurations options in the given model
        /// </summary>
        /// <param name="vm">The variability model containing the binary options and their constraints.</param>
        /// <returns>Returns a list of configurations, in which a configuration is a list of SELECTED binary options (deselected options are not present)</returns>
        List<List<BinaryOption>> generateAllVariantsFast(VariabilityModel vm);
        
        
        /// <summary>
        /// Simulates a simple method to get valid configurations of binary options of a variability model. The randomness is simulated by the modulu value.
        /// We take only the modulu'th configuration into the result set based on the CSP solvers output.
        /// </summary>
        /// <param name="vm">The variability model containing the binary options and their constraints.</param>
        /// <param name="treshold">Maximum number of configurations</param>
        /// <param name="modulu">Each configuration that is % modulu == 0 is taken to the result set</param>
        /// <returns>Returns a list of configurations, in which a configuration is a list of SELECTED binary options (deselected options are not present</returns>
        List<List<BinaryOption>> generateRandomVariants(VariabilityModel vm, int treshold, int modulu);
        

        //Configuration size
        /// <summary>
        /// Based on a given (partial) configuration and a variability, we aim at finding the smallest (or largest if minimize == false) valid configuration that has all options.
        /// </summary>
        /// <param name="config">The (partial) configuration which needs to be expaned to be valid.</param>
        /// <param name="vm">Variability model containing all options and their constraints.</param>
        /// <param name="minimize">If true, we search for the smallest (in terms of selected options) valid configuration. If false, we search for the largest one.</param>
        /// <param name="unWantedOptions">Binary options that we do not want to become part of the configuration. Might be part if there is no other valid configuration without them.</param>
        /// <returns>The valid configuration (or null if there is none) that satisfies the VM and the goal.</returns>
        List<BinaryOption> minimizeConfig(List<BinaryOption> config, VariabilityModel vm, bool minimize, List<BinaryOption> unWantedOptions);

        /// <summary>
        /// Based on a given (partial) configuration and a variability, we aim at finding all optimally maximal or minimal (in terms of selected binary options) configurations.
        /// </summary>
        /// <param name="config">The (partial) configuration which needs to be expaned to be valid.</param>
        /// <param name="vm">Variability model containing all options and their constraints.</param>
        /// <param name="minimize">If true, we search for the smallest (in terms of selected options) valid configuration. If false, we search for the largest one.</param>
        /// <param name="unwantedOptions">Binary options that we do not want to become part of the configuration. Might be part if there is no other valid configuration without them</param>
        /// <returns>A list of configurations that satisfies the VM and the goal (or null if there is none).</returns>
        List<List<BinaryOption>> maximizeConfig(List<BinaryOption> config, VariabilityModel vm, bool minimize, List<BinaryOption> unwantedOptions);

        /// <summary>
        /// The method aims at finding a configuration which is similar to the given configuration, but does not contain the optionToBeRemoved. If further options need to be removed from the given configuration, they are outputed in removedElements.
        /// </summary>
        /// <param name="optionToBeRemoved">The binary configuration option that must not be part of the new configuration.</param>
        /// <param name="originalConfig">The configuration for which we want to find a similar one.</param>
        /// <param name="removedElements">If further options need to be removed from the given configuration to build a valid configuration, they are outputed in this list.</param>
        /// <param name="vm">The variability model containing all options and their constraints.</param>
        /// <returns>A configuration that is valid, similar to the original configuration and does not contain the optionToBeRemoved.</returns>
        List<BinaryOption> generateConfigWithoutOption(BinaryOption optionToBeRemoved, List<BinaryOption> originalConfig, out List<BinaryOption> removedElements, VariabilityModel vm);

        List<List<BinaryOption>> GenerateRLinear(VariabilityModel vm, int treshold, int solverTimeout, BackgroundWorker worker);

        

        //Old: Refactoring of VM
        //Determine the boundaries in terms of cardinality of a product at which (a) valid products can be generated (maxBoundary) and (b) the first invalid products can be generated (minBoundary)
        //int determineBoundary(VariabilityModel vm, RuntimeProperty rp, NFPConstraint constraint, bool min, bool withInteractions, bool invalidBoundary);//searching for invalid or valid products?
        //Computes Configurations that have a given number of features: it tries to find at least a configuration for each feature or #repetitions and at maximum a configuration for each feature or #repetitions
        //List<List<BinaryOption>> getConfigWithNbOfFeatures(int nbOfFeatures, VariabilityModel vm, bool withInteractions, int repetitions, List<BinaryOption> forbiddenOptions);

        //Old: Refactoring of VM
        //List<Element> getInvalidVariantAtCardinality(int i, NFPConstraint constraint, FeatureModel fm, RuntimeProperty rp, Dictionary<int, List<List<Element>>> combiNotToBeSelected, bool findInvalid);
        //List<List<Element>> getAllConfigsForCardinality(int nbOfFeatures, FeatureModel fm, bool withDerivatives);
        //List<Element> determineSetOfValidNegativeFeatures(int nbOfFeatures, FeatureModel fm, bool withDerivatives, List<Element> forbiddenFeatures, RuntimeProperty rp, NFPConstraint constraint);


        //Old:
        //For feature uncertainty
        //List<Configuration> getMinimalConfigurationCSP(FeatureModel fm, List<Configuration> unWantedConfigurations, Element selectedFeature, int minsize);
    }
}
