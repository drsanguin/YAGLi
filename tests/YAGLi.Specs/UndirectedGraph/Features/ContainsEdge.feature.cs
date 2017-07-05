﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace YAGLi.Specs.UndirectedGraph.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Check if a undirected graph contains one ore more edge(s)")]
    public partial class CheckIfAUndirectedGraphContainsOneOreMoreEdgeSFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ContainsEdge.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Check if a undirected graph contains one ore more edge(s)", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who allow parallel edges contains an edge")]
        public virtual void CheckThatAUndirectedGraphWhoAllowParallelEdgesContainsAnEdge()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who allow parallel edges contains an edge", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table1.AddRow(new string[] {
                        "v0"});
            table1.AddRow(new string[] {
                        "v1"});
            table1.AddRow(new string[] {
                        "v2"});
            table1.AddRow(new string[] {
                        "v3"});
            table1.AddRow(new string[] {
                        "v4"});
#line 6
 testRunner.And("the vertices", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table2.AddRow(new string[] {
                        "v0",
                        "v1"});
            table2.AddRow(new string[] {
                        "v1",
                        "v4"});
            table2.AddRow(new string[] {
                        "v4",
                        "v4"});
            table2.AddRow(new string[] {
                        "v4",
                        "v3"});
            table2.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 13
 testRunner.And("the edges", ((string)(null)), table2, "And ");
#line 20
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table3.AddRow(new string[] {
                        "v0",
                        "v1"});
#line 21
 testRunner.When("I check that the graph contains the edge", ((string)(null)), table3, "When ");
#line 24
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who allow parallel edges does not contains an edge")]
        public virtual void CheckThatAUndirectedGraphWhoAllowParallelEdgesDoesNotContainsAnEdge()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who allow parallel edges does not contains an edge", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table4.AddRow(new string[] {
                        "v0"});
            table4.AddRow(new string[] {
                        "v1"});
            table4.AddRow(new string[] {
                        "v2"});
            table4.AddRow(new string[] {
                        "v3"});
            table4.AddRow(new string[] {
                        "v4"});
#line 29
 testRunner.And("the vertices", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table5.AddRow(new string[] {
                        "v0",
                        "v1"});
            table5.AddRow(new string[] {
                        "v1",
                        "v4"});
            table5.AddRow(new string[] {
                        "v4",
                        "v4"});
            table5.AddRow(new string[] {
                        "v4",
                        "v3"});
            table5.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 36
 testRunner.And("the edges", ((string)(null)), table5, "And ");
#line 43
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table6.AddRow(new string[] {
                        "v0",
                        "v4"});
#line 44
 testRunner.When("I check that the graph contains the edge", ((string)(null)), table6, "When ");
#line 47
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who disallow parallel edges contains a edge")]
        public virtual void CheckThatAUndirectedGraphWhoDisallowParallelEdgesContainsAEdge()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who disallow parallel edges contains a edge", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.And("the property disallow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table7.AddRow(new string[] {
                        "v0"});
            table7.AddRow(new string[] {
                        "v1"});
            table7.AddRow(new string[] {
                        "v2"});
            table7.AddRow(new string[] {
                        "v3"});
            table7.AddRow(new string[] {
                        "v4"});
#line 52
 testRunner.And("the vertices", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table8.AddRow(new string[] {
                        "v0",
                        "v1"});
            table8.AddRow(new string[] {
                        "v1",
                        "v4"});
            table8.AddRow(new string[] {
                        "v4",
                        "v4"});
            table8.AddRow(new string[] {
                        "v4",
                        "v3"});
            table8.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 59
 testRunner.And("the edges", ((string)(null)), table8, "And ");
#line 66
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table9.AddRow(new string[] {
                        "v0",
                        "v1"});
#line 67
 testRunner.When("I check that the graph contains the edge", ((string)(null)), table9, "When ");
#line 70
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who disallow parallel edges does not contains a edg" +
            "e")]
        public virtual void CheckThatAUndirectedGraphWhoDisallowParallelEdgesDoesNotContainsAEdge()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who disallow parallel edges does not contains a edg" +
                    "e", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("the property disallow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table10.AddRow(new string[] {
                        "v0"});
            table10.AddRow(new string[] {
                        "v1"});
            table10.AddRow(new string[] {
                        "v2"});
            table10.AddRow(new string[] {
                        "v3"});
            table10.AddRow(new string[] {
                        "v4"});
#line 75
 testRunner.And("the vertices", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table11.AddRow(new string[] {
                        "v0",
                        "v1"});
            table11.AddRow(new string[] {
                        "v1",
                        "v4"});
            table11.AddRow(new string[] {
                        "v4",
                        "v4"});
            table11.AddRow(new string[] {
                        "v4",
                        "v3"});
            table11.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 82
 testRunner.And("the edges", ((string)(null)), table11, "And ");
#line 89
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table12.AddRow(new string[] {
                        "v0",
                        "v4"});
#line 90
 testRunner.When("I check that the graph contains the edge", ((string)(null)), table12, "When ");
#line 93
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who allow parallel edges contains edges")]
        public virtual void CheckThatAUndirectedGraphWhoAllowParallelEdgesContainsEdges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who allow parallel edges contains edges", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table13.AddRow(new string[] {
                        "v0"});
            table13.AddRow(new string[] {
                        "v1"});
            table13.AddRow(new string[] {
                        "v2"});
            table13.AddRow(new string[] {
                        "v3"});
            table13.AddRow(new string[] {
                        "v4"});
#line 98
 testRunner.And("the vertices", ((string)(null)), table13, "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table14.AddRow(new string[] {
                        "v0",
                        "v1"});
            table14.AddRow(new string[] {
                        "v1",
                        "v4"});
            table14.AddRow(new string[] {
                        "v4",
                        "v4"});
            table14.AddRow(new string[] {
                        "v4",
                        "v3"});
            table14.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 105
 testRunner.And("the edges", ((string)(null)), table14, "And ");
#line 112
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table15.AddRow(new string[] {
                        "v0",
                        "v1"});
            table15.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 113
 testRunner.When("I check that the graph contains the edges", ((string)(null)), table15, "When ");
#line 117
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who allow parallel edges does not contains edges")]
        public virtual void CheckThatAUndirectedGraphWhoAllowParallelEdgesDoesNotContainsEdges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who allow parallel edges does not contains edges", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table16.AddRow(new string[] {
                        "v0"});
            table16.AddRow(new string[] {
                        "v1"});
            table16.AddRow(new string[] {
                        "v2"});
            table16.AddRow(new string[] {
                        "v3"});
            table16.AddRow(new string[] {
                        "v4"});
#line 122
 testRunner.And("the vertices", ((string)(null)), table16, "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table17.AddRow(new string[] {
                        "v0",
                        "v1"});
            table17.AddRow(new string[] {
                        "v1",
                        "v4"});
            table17.AddRow(new string[] {
                        "v4",
                        "v4"});
            table17.AddRow(new string[] {
                        "v4",
                        "v3"});
            table17.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 129
 testRunner.And("the edges", ((string)(null)), table17, "And ");
#line 136
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table18.AddRow(new string[] {
                        "v0",
                        "v1"});
            table18.AddRow(new string[] {
                        "v0",
                        "v4"});
#line 137
 testRunner.When("I check that the graph contains the edges", ((string)(null)), table18, "When ");
#line 141
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who disallow parallel edges contains edges")]
        public virtual void CheckThatAUndirectedGraphWhoDisallowParallelEdgesContainsEdges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who disallow parallel edges contains edges", ((string[])(null)));
#line 143
this.ScenarioSetup(scenarioInfo);
#line 144
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 145
 testRunner.And("the property disallow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table19.AddRow(new string[] {
                        "v0"});
            table19.AddRow(new string[] {
                        "v1"});
            table19.AddRow(new string[] {
                        "v2"});
            table19.AddRow(new string[] {
                        "v3"});
            table19.AddRow(new string[] {
                        "v4"});
#line 146
 testRunner.And("the vertices", ((string)(null)), table19, "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table20.AddRow(new string[] {
                        "v0",
                        "v1"});
            table20.AddRow(new string[] {
                        "v1",
                        "v4"});
            table20.AddRow(new string[] {
                        "v4",
                        "v4"});
            table20.AddRow(new string[] {
                        "v4",
                        "v3"});
            table20.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 153
 testRunner.And("the edges", ((string)(null)), table20, "And ");
#line 160
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table21.AddRow(new string[] {
                        "v0",
                        "v1"});
            table21.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 161
 testRunner.When("I check that the graph contains the edges", ((string)(null)), table21, "When ");
#line 165
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph who disallow parallel edges does not contains edges" +
            "")]
        public virtual void CheckThatAUndirectedGraphWhoDisallowParallelEdgesDoesNotContainsEdges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph who disallow parallel edges does not contains edges" +
                    "", ((string[])(null)));
#line 167
this.ScenarioSetup(scenarioInfo);
#line 168
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 169
 testRunner.And("the property disallow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table22.AddRow(new string[] {
                        "v0"});
            table22.AddRow(new string[] {
                        "v1"});
            table22.AddRow(new string[] {
                        "v2"});
            table22.AddRow(new string[] {
                        "v3"});
            table22.AddRow(new string[] {
                        "v4"});
#line 170
 testRunner.And("the vertices", ((string)(null)), table22, "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table23.AddRow(new string[] {
                        "v0",
                        "v1"});
            table23.AddRow(new string[] {
                        "v1",
                        "v4"});
            table23.AddRow(new string[] {
                        "v4",
                        "v4"});
            table23.AddRow(new string[] {
                        "v4",
                        "v3"});
            table23.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 177
 testRunner.And("the edges", ((string)(null)), table23, "And ");
#line 184
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table24.AddRow(new string[] {
                        "v0",
                        "v1"});
            table24.AddRow(new string[] {
                        "v0",
                        "v4"});
#line 185
 testRunner.When("I check that the graph contains the edges", ((string)(null)), table24, "When ");
#line 189
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion