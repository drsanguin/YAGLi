Feature: AdjacentVerticesOf

Scenario: Retrieve the adjacent vertices of a vertex not contained in DirectedGraph
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
	When I retrieve the adjacent vertices of the vertex "v5"
	Then I get an empty list of vertices

Scenario: Retrieve the adjacent vertices of a vertex contained in a DirectedGraph who allow loops
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
	When I retrieve the adjacent vertices of the vertex "v4"
	Then I get the vertices
	| Name |
	| v1   |
	| v4   |
	| v3   |

Scenario: Retrieve the adjacent vertices of a vertex contained in a DirectedGraph who disallow loops
	Given the property disallow loops
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
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I retrieve the adjacent vertices of the vertex "v4"
	Then I get the vertices
	| Name |
	| v1   |
	| v3   |