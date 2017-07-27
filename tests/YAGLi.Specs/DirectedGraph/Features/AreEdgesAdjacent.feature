Feature: AreEdgesAdjacent

Scenario: Check if two edges not contained in a DirectedGraph are adjacent
	Given the property allow loops
	Given the property allow parallel edges
	Given the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	Given the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v1   | v0   |
	| v0   | v2   |
	Then I get the answer false

Scenario: Check if two edges contained in a DirectedGraph are adjacent
	Given the property allow loops
	Given the property allow parallel edges
	Given the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	Given the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the directed graph created with them
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	Then I get the answer true