Feature: IncidentEdgesInto

Scenario: Get the incident edges of a vertex not contained in a DirectedGraph
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
	When I retrieve the incident edges into "v5"
	Then I get an empty list of edges

Scenario: Get the incident edges of a vertex contained in a DirectedGraph
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
	When I retrieve the incident edges into "v4"
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |