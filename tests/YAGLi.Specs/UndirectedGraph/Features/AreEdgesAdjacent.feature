Feature: Check if two edges are adjacent in a undirected graph

Scenario: Check that two edges who share a common vertex in a undirected graph are adjacent
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
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	Then I get the answer true

Scenario: Check that two vertices who do not share a common vertex in a undirected graph are not adjacent
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
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v4   |
	Then I get the answer false

Scenario: Check that two vertices with one not contains in the graph but who share a common vertex are not adjacent
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
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	And the undirected graph created with them
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v4   |
	Then I get the answer false