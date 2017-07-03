Feature: Check if two vertices are adjacent in a undirected graph

Scenario: Check that two vertices connected in a undirected graph are adjacent
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
	When I check if the vertices "v0" and "v1" are adjacent
	Then I get the answer true

Scenario: Check that two vertices not connected in a undirected graph are not adjacent
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
	When I check if the vertices "v0" and "v2" are adjacent
	Then I get the answer false