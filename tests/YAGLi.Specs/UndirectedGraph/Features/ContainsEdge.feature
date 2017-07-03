Feature: Check if a undirected graph contains one ore more edge(s)

Scenario: Check that a undirected graph who allow parallel edges contains a edge
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
	And the undirected graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the answer true

Scenario: Check that a undirected graph who allow parallel edges contains a edge with the same ends
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
	And the undirected graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the answer false

Scenario: Check that a undirected graph who disallow parallel edges contains a edge with the same ends
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
	And the undirected graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the answer true

Scenario: Check that a undirected graph who allow parallel edges contains edges
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
	And the undirected graph created with them
	When I check that the graph contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that a undirected graph who allow parallel edges does not contains edges with the same ends
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
	And the undirected graph created with them
	When I check that the graph contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer false

Scenario: Check that a undirected graph who disallow parallel edges contains edges with the same ends
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
	And the undirected graph created with them
	When I check that the graph contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true