Feature: Removing vertex/vertices from a undirected graph

Scenario: Remove a vertex from a undirected graph
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
	When I remove the vertex "v4" from the undirected graph
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	And he contains the edges
    | End1 | End2 |
    | v0   | v1   |

Scenario: Remove vertices from a undirected graph
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
	When I remove the vertices from the undirected graph
	| Name |
	| v0   |
	| v1   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v2   |
	| v3   |
	| v4   |
	And he contains the edges
	| End1 | End2 |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |