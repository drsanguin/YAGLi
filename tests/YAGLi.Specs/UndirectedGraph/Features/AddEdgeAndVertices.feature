Feature: Adding edge(s), with her/their vertices, to a undirected graph

Scenario: Add edge and vertices to a undirected graph
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
	When I add the following edge with her vertices
	| End1 | End2 |
	| v5   | v6   |
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
	| v5   | v6   |

Scenario: Add edges and vertices to a undirected graph
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
	When I add the edges and vertices with their vertices
    | End1 | End2 |
	| v5   | v6   |
	| v0   | v7   |
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
	| v7   |
	And he contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v5   | v6   |
	| v0   | v7   |