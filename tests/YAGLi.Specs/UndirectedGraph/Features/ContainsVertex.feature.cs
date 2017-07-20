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
    [NUnit.Framework.DescriptionAttribute("Check if a undirected graph contains one ore more vertex/vertices")]
    public partial class CheckIfAUndirectedGraphContainsOneOreMoreVertexVerticesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ContainsVertex.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Check if a undirected graph contains one ore more vertex/vertices", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph contains the expected vertex")]
        public virtual void CheckThatAUndirectedGraphContainsTheExpectedVertex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph contains the expected vertex", ((string[])(null)));
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
#line 21
 testRunner.When("I check that the graph contains the vertex \"v0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph does not contains the expected vertex")]
        public virtual void CheckThatAUndirectedGraphDoesNotContainsTheExpectedVertex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph does not contains the expected vertex", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table3.AddRow(new string[] {
                        "v0"});
            table3.AddRow(new string[] {
                        "v1"});
            table3.AddRow(new string[] {
                        "v2"});
            table3.AddRow(new string[] {
                        "v3"});
            table3.AddRow(new string[] {
                        "v4"});
#line 27
 testRunner.And("the vertices", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table4.AddRow(new string[] {
                        "v0",
                        "v1"});
            table4.AddRow(new string[] {
                        "v1",
                        "v4"});
            table4.AddRow(new string[] {
                        "v4",
                        "v4"});
            table4.AddRow(new string[] {
                        "v4",
                        "v3"});
            table4.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 34
 testRunner.And("the edges", ((string)(null)), table4, "And ");
#line 41
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("I check that the graph contains the vertex \"v5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph contains the expected IEnumerable of vertices")]
        public virtual void CheckThatAUndirectedGraphContainsTheExpectedIEnumerableOfVertices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph contains the expected IEnumerable of vertices", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table5.AddRow(new string[] {
                        "v0"});
            table5.AddRow(new string[] {
                        "v1"});
            table5.AddRow(new string[] {
                        "v2"});
            table5.AddRow(new string[] {
                        "v3"});
            table5.AddRow(new string[] {
                        "v4"});
#line 48
 testRunner.And("the vertices", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table6.AddRow(new string[] {
                        "v0",
                        "v1"});
            table6.AddRow(new string[] {
                        "v1",
                        "v4"});
            table6.AddRow(new string[] {
                        "v4",
                        "v4"});
            table6.AddRow(new string[] {
                        "v4",
                        "v3"});
            table6.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 55
 testRunner.And("the edges", ((string)(null)), table6, "And ");
#line 62
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table7.AddRow(new string[] {
                        "v0"});
            table7.AddRow(new string[] {
                        "v3"});
            table7.AddRow(new string[] {
                        "v4"});
#line 63
 testRunner.When("I check that the graph contains the following IEnumerable of vertices", ((string)(null)), table7, "When ");
#line 68
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph contains the expected array of vertices")]
        public virtual void CheckThatAUndirectedGraphContainsTheExpectedArrayOfVertices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph contains the expected array of vertices", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table8.AddRow(new string[] {
                        "v0"});
            table8.AddRow(new string[] {
                        "v1"});
            table8.AddRow(new string[] {
                        "v2"});
            table8.AddRow(new string[] {
                        "v3"});
            table8.AddRow(new string[] {
                        "v4"});
#line 73
 testRunner.And("the vertices", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table9.AddRow(new string[] {
                        "v0",
                        "v1"});
            table9.AddRow(new string[] {
                        "v1",
                        "v4"});
            table9.AddRow(new string[] {
                        "v4",
                        "v4"});
            table9.AddRow(new string[] {
                        "v4",
                        "v3"});
            table9.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 80
 testRunner.And("the edges", ((string)(null)), table9, "And ");
#line 87
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table10.AddRow(new string[] {
                        "v0"});
            table10.AddRow(new string[] {
                        "v3"});
            table10.AddRow(new string[] {
                        "v4"});
#line 88
 testRunner.When("I check that the graph contains the following array of vertices", ((string)(null)), table10, "When ");
#line 93
 testRunner.Then("I get the answer true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph does not contains the expected IEnumerable of verti" +
            "ces")]
        public virtual void CheckThatAUndirectedGraphDoesNotContainsTheExpectedIEnumerableOfVertices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph does not contains the expected IEnumerable of verti" +
                    "ces", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table11.AddRow(new string[] {
                        "v0"});
            table11.AddRow(new string[] {
                        "v1"});
            table11.AddRow(new string[] {
                        "v2"});
            table11.AddRow(new string[] {
                        "v3"});
            table11.AddRow(new string[] {
                        "v4"});
#line 98
 testRunner.And("the vertices", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table12.AddRow(new string[] {
                        "v0",
                        "v1"});
            table12.AddRow(new string[] {
                        "v1",
                        "v4"});
            table12.AddRow(new string[] {
                        "v4",
                        "v4"});
            table12.AddRow(new string[] {
                        "v4",
                        "v3"});
            table12.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 105
 testRunner.And("the edges", ((string)(null)), table12, "And ");
#line 112
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table13.AddRow(new string[] {
                        "v0"});
            table13.AddRow(new string[] {
                        "v3"});
            table13.AddRow(new string[] {
                        "v4"});
            table13.AddRow(new string[] {
                        "v5"});
#line 113
 testRunner.When("I check that the graph contains the following IEnumerable of vertices", ((string)(null)), table13, "When ");
#line 119
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that a undirected graph does not contains the expected array of vertices")]
        public virtual void CheckThatAUndirectedGraphDoesNotContainsTheExpectedArrayOfVertices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that a undirected graph does not contains the expected array of vertices", ((string[])(null)));
#line 121
this.ScenarioSetup(scenarioInfo);
#line 122
 testRunner.Given("the property allow loops", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 123
 testRunner.And("the property allow parallel edges", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table14.AddRow(new string[] {
                        "v0"});
            table14.AddRow(new string[] {
                        "v1"});
            table14.AddRow(new string[] {
                        "v2"});
            table14.AddRow(new string[] {
                        "v3"});
            table14.AddRow(new string[] {
                        "v4"});
#line 124
 testRunner.And("the vertices", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "End1",
                        "End2"});
            table15.AddRow(new string[] {
                        "v0",
                        "v1"});
            table15.AddRow(new string[] {
                        "v1",
                        "v4"});
            table15.AddRow(new string[] {
                        "v4",
                        "v4"});
            table15.AddRow(new string[] {
                        "v4",
                        "v3"});
            table15.AddRow(new string[] {
                        "v4",
                        "v3"});
#line 131
 testRunner.And("the edges", ((string)(null)), table15, "And ");
#line 138
 testRunner.And("the undirected graph created with them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table16.AddRow(new string[] {
                        "v0"});
            table16.AddRow(new string[] {
                        "v3"});
            table16.AddRow(new string[] {
                        "v4"});
            table16.AddRow(new string[] {
                        "v5"});
#line 139
 testRunner.When("I check that the graph contains the following array of vertices", ((string)(null)), table16, "When ");
#line 145
 testRunner.Then("I get the answer false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
