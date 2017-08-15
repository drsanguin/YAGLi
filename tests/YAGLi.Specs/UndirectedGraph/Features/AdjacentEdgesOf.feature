Feature: Retrieve a list of adjacent edges from a undirected graph

Scenario: Get the adjacent edges of an edge located into a undirected graph who allow loops and parallel edges
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
	| v3   | v4   |
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v4   | v3   |
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v3   | v4   |
	| v4   | v4   |

Scenario: Get the adjacent edges of an edge not located into a undirected graph who allow loops and parallel edges
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
	| v3   | v4   |
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v0   | v4   |
	Then I get an empty list of edges

Scenario: Get the adjacent edges of an edge not located into a undirected graph who allow loops and disallow parallel edges
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
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v0   | v4   |
	Then I get an empty list of edges

Scenario: Get the adjacent edges of an edge equal to an edge located into a undirected graph who allow loops and disallow parallel edges
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
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v3   | v4   |
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |