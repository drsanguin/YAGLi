Feature: IncidentVerticesOf

Scenario: Get the incident vertices of an edge not contained in a DirectedGraph
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
	When I retrieve the incident vertices of the edge
	| End1 | End2 |
	| v1   | v0   |
	Then I get an empty list of vertices

Scenario: Get the incident vertices of an edge contained in a DirectedGraph
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
	When I retrieve the incident vertices of the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the vertices
	| Name |
	| v0   |
	| v1   |

Scenario: Get the incident vertices of an loop edge contained in a DirectedGraph
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
	When I retrieve the incident vertices of the edge
	| End1 | End2 |
	| v4   | v4   |
	Then I get the vertices
	| Name |
	| v4   |