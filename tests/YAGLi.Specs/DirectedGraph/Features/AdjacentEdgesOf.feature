Feature: AdjacentEdgesOf

Scenario: Retrieve the adjacent edges of an edge not contained in a DirectedGraph
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
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v0   | v2   |
	Then I get an empty list of edges

Scenario: Retrieve the adjacent edges of an edge contained in a DirectedGraph who disallow parallel edges
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
	And the directed graph created with them
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v4   | v3   |
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |

Scenario: Retrieve the adjacent edges of an edge contained in a DirectedGraph who allow parallel edges
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
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v4   | v3   |
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |