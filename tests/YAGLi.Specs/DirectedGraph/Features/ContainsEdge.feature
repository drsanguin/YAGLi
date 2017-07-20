Feature: ContainsEdge

Scenario: Check that a directed graph who allow parallel edges contains an edge
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the answer true

Scenario: Check that a directed graph who allow parallel edges does not contains an edge
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v1   | v0   |
	Then I get the answer false

Scenario: Check that a directed graph who disallow parallel edges contains a edge
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the answer true

Scenario: Check that a directed graph who disallow parallel edges does not contains a edge
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v1   | v0   |
	Then I get the answer false

Scenario: Check that a directed graph who allow parallel edges contains a IEnumerable of edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following IEnumerable of edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that a directed graph who allow parallel edges contains an array of edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following array of edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that a directed graph who allow parallel edges does not contains a IEnumerable of edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following IEnumerable of edges
	| End1 | End2 |
	| v1   | v0   |
	| v0   | v4   |
	Then I get the answer false

Scenario: Check that a directed graph who allow parallel edges does not contains an array of edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following array of edges
	| End1 | End2 |
	| v1   | v0   |
	| v0   | v4   |
	Then I get the answer false

Scenario: Check that a directed graph who disallow parallel edges contains a IEnumerable of edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following IEnumerable of edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that a directed graph who disallow parallel edges contains an array of edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following array of edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that a directed graph who disallow parallel edges does not contains a IEnumerable of edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following IEnumerable of edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v4   |
	Then I get the answer false

Scenario: Check that a directed graph who disallow parallel edges does not contains an array of edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check that the graph contains the following array of edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v4   |
	Then I get the answer false