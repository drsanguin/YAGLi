﻿using System.Collections.Generic;
using TechTalk.SpecFlow;
using YAGLi.Specs.Builders;
using YAGLi.Specs.Validators;
using YAGLi.Tests.Utils;

namespace YAGLi.Specs.Steps
{
    [Binding]
    public class AddEdgeSteps
    {
        UndirectedGraphBuilder _builder;
        GraphValidator _validator;

        public AddEdgeSteps(UndirectedGraphBuilder builder, GraphValidator validator)
        {
            _builder = builder;
            _validator = validator;
        }

        [When(@"I add the edges")]
        public void WhenIAddTheEdges(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.AddEdges(edges);
        }

        [When(@"I add the edge")]
        public void WhenIAddTheEdge(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.AddEdge(edge);
        }

        [When(@"I add the following edge with her vertices")]
        public void WhenIAddTheEdgeWithTheVerticesAnd(Edge<Vertex> edge)
        {
            _validator.Subject = _builder.Instance.AddEdgeAndVertices(edge);
        }

        [When(@"I add the edges and vertices with their vertices")]
        public void WhenIAddTheEdgesAndVertices(IEnumerable<Edge<Vertex>> edges)
        {
            _validator.Subject = _builder.Instance.AddEdgesAndVertices(edges);
        }
    }
}