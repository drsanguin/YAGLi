Feature: Get the incident vertices of a given edge in a undirected graph

Scenario: Get the incident vertices of a edge contained in a undirected graph
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
	When I get the incident vertices of the edge
	| End1 | End2 |
	| v1   | v4   |
	Then I get the vertices
	| Name |
	| v1   |
	| v4   |

Scenario: Get the incident vertices of a edge not contained in a undirected graph
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
	When I get the incident vertices of the edge
	| End1 | End2 |
	| v0   | v4   |
	Then I get an empty list of vertices

Scenario: Get the incident vertices of a loop edge contained in a undirected graph
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
	When I get the incident vertices of the edge
	| End1 | End2 |
	| v4   | v4   |
	Then I get the vertices
	| Name |
	| v4   |