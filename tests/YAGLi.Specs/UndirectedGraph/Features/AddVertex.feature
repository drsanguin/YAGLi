Feature: Adding vertex/vertices to a undirected graph

Scenario: Add a vertex to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the vertex "v5"
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add vertices to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the vertices
    | Name |
	| v5   |
	| v6   |
	Then I get a new undirected graph
	And he contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	And he contains the edges
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |